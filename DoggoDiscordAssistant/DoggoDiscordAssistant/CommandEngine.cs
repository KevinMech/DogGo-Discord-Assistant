using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    class CommandEngine
    {
        private static List<Command> AvailableCommands;

        /// <summary>
        /// Queries the input of users chat and retrieves the command, flag and flag parameters
        /// </summary>
        /// <param name="message"></param>
        public static void parseInput(DoggoDiscordAssistant bot, Server server, Discord.Channel channel, string message)
        {
            if (message[0] == '>')
            {
                //Split the message into seperate words and check to see if each word corresponds to a command
                message = message.Remove(0, 1);
                string[] splitMessage = message.Split(' ');
                foreach(Command command in AvailableCommands.ToList())
                {
                    foreach(String word in splitMessage)
                    {
                        if (word == command.Identifier)
                        {
                            command.Execute(channel);
                            if (bot.Debug) Logging.consoleLog("Command Executed!", Logging.logType.System);
                        }
                    }
                }
            }
        }

        public static void GreetUser(Server server)
        {
            server.ServerAPI.DefaultChannel.SendMessage(server.Welcome);
        }
    }
}
