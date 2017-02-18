using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    class AdminConsole
    {
        public static void parseAdminInput(string message, DoggoDiscordAssistant bot)
        {
            //Check to see that input has correct symbol
            if(message.Length > 0 && message[0] == '/')
            {
                string filteredMessage = message.Remove(0, 1).ToLower();
                string[] command = filteredMessage.Split(' ');
                switch (command[0])
                {
                    case "debug":
                        bot.Debug = !bot.Debug;
                        if (bot.Debug) Console.WriteLine("Debug ON!");
                        else Console.WriteLine("Debug OFF!");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
