using System;
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

            if (message[0] == '>')
            {
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
                        if (bot.Debug) Logging.consoleLog( user + " has executed command: " + command + Environment.NewLine + "Parameter: " + parameter, Logging.logType.Debug);
                        rcommand.Execute(channel);
                    }
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

        public static void GreetUser(Server server)
        {
            server.ServerAPI.DefaultChannel.SendMessage(server.Welcome);
        }
    }
}
