using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    class CommandEngine
    {
        /// <summary>
        /// Queries the input of users chat and retrieves the command, flag and flag parameters
        /// </summary>
        /// <param name="message"></param>
        public static void parseInput(DoggoDiscordAssistant bot, Server server, Discord.Channel channel, string message)
        {
            string command;
            Dictionary<string, string> flags = new Dictionary<string, string>();

            if (message[0] == '>')
            {
                //Discard command symbol and split the message into a list
                message = message.Remove(0, 1);
                List<string> splitMessage = message.Split(' ').ToList<string>();
                //Grab the command and discard it from the list
                command = splitMessage[0];
                splitMessage.RemoveAt(0);
                foreach(Command dcommand in server.AvailableCommands.ToList())
                {
                    if (command == dcommand.Identifier)
                    {
                        dcommand.Execute(channel);
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
