using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    class CommandEngine
    {
        public static List<Command> AvailableCommands { get; private set; } = new List<Command> { };

        /*Temporary way to set all commands available that the bot can execute
        Will be removed eventually and replaced with a better option
        */
        private static void setAvailableCommands()
        {
            AvailableCommands.Clear();
            Ping ping = new Ping();
            AvailableCommands.Add(ping);
        }

        /// <summary>
        /// Queries the input of users chat and retrieves the command, flag and flag parameters
        /// </summary>
        /// <param name="message"></param>
        public static void parseInput(DoggoDiscordAssistant bot, Discord.Channel channel, string message)
        {
            if (message[0] == '>')
            {
                setAvailableCommands();
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
    }
}
