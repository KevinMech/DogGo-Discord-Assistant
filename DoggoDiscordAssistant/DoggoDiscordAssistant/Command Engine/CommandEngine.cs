﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    class CommandEngine
    {
        static List<string> splitMessage = new List<string>();
        /// <summary>
        /// Queries the input of users chat and retrieves the command, flag and flag parameters
        /// </summary>
        /// <param name="message"></param>
        public static void parseInput(DoggoDiscordAssistant bot, Server server, Discord.Channel channel, Discord.User user, string message)
        {
            string command;
            string parameter;
            Dictionary<string, string> flags = new Dictionary<string, string>();
            //Discard command symbol and split the message into a list
            message = message.Remove(0, 1);
            splitMessage = message.Split(' ').ToList<string>();
            //Grab the command and discard it from the list
            command = splitMessage[0];
            splitMessage.RemoveAt(0);
            /*If command matches a registered command identifier, continue parsing for the parameter,
            flags and flag parameter, and then execute the command*/
            foreach(Command rcommand in server.AvailableCommands.ToList())
            {
                if (command == rcommand.Identifier)
                {
                    parameter = parseParameter();
                    flags = parseFlags();
                    if (bot.Debug)
                    {
                        Logging.consoleLog(user.Name + " has executed a command! " + Environment.NewLine + "Command: " + command + Environment.NewLine + "Parameter: " + parameter, Logging.logType.Debug);
                        foreach (KeyValuePair<string, string> flag in flags)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Flag: " + flag.Key + " Parameter: " + flag.Value, Logging.logType.Debug);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    rcommand.Execute(server, channel, user, parameter, flags);
                }
            }
        }

        private static string parseParameter()
        {
            string parameter = null;
            foreach(string word in splitMessage.ToList())
            {
                if (word[0] == '-') break;
                else {
                    parameter += word + " ";
                    splitMessage.Remove(word);
                }
            }
            if (parameter != null) parameter.TrimEnd();
            return parameter;
        }

        private static Dictionary<string, string> parseFlags()
        {
            Dictionary<string, string> flags = new Dictionary<string, string>();
            string flag = null;
            string parameter = null;
            //Grab the first flag, delete its dash character, store it in string, then discard it
            flag = splitMessage[0].Remove(0, 1);
            splitMessage.Remove('-' + flag);
            foreach(string word in splitMessage.ToList())
            {
                if(word[0] == '-')
                {
                    //Store the flag and parameter inside the dictionary, and start a new flag
                    flags.Add(flag, parameter);
                    flag = word.Remove(0, 1);
                    parameter = "";
                }
                else
                {
                    parameter += word + " ";
                }
            }
            flags.Add(flag, parameter);
            return flags;
        }
        public static void GreetUser(Server server)
        {
            server.ServerAPI.DefaultChannel.SendMessage(server.Welcome);
        }
    }
}
