using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace DoggoDiscordAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            string botToken = null;
            while(botToken == null)
            {
                Console.WriteLine("Would you like to run the offical client or the test client?");
                Console.WriteLine("1. Doggo Discord Assistant");
                Console.WriteLine("2. Doggo Test Assistant");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Official Client Selected!");
                    botToken = Token.getBotToken;
                }
                else if (input == "2")
                {
                    Console.WriteLine("Test Client Selected!");
                    botToken = Token.getTestToken;
                }
                else Console.WriteLine("Please type either a 1 or 2 and try again");
                Console.WriteLine();
            }
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            DoggoDiscordAssistant doggodiscordassistant = new DoggoDiscordAssistant(botToken, metadata =>
            {
                metadata.AppName = "DogGo Discord Assistant";
                metadata.AppVersion = "0.1.0";
                metadata.AppUrl = "https://github.com/KevinMech/DogGo-Discord-Assistant";
                metadata.LogLevel = LogSeverity.Error;
                metadata.LogHandler += Logging.APIErrorLogHandling;
            });
        }
    }
}
