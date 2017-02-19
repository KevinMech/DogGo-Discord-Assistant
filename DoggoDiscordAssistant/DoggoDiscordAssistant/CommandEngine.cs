using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    class CommandEngine
    {
        public static List<Command> AvailableCommands { get; private set; }

        /// <summary>
        /// Queries the input of users chat and retrieves the command, flag and flag parameters
        /// </summary>
        /// <param name="message"></param>
        public static void parseInput(DoggoDiscordAssistant bot, string message)
        {
            //Check to see if message starts with command symbol.
            if (message[0] == '>')
            {
                string[] splitMessage = message.Split(' ');
                foreach(Command command in AvailableCommands)
                {
                    foreach(String word in splitMessage)
                    {
                        if (word == command.Identifier)
                        {
                            command.Execute();
                            if (bot.Debug) Logging.consoleLog("Command Executed!", Logging.logType.System);
                        }
                    }
                }
            }
        }
    }
}
