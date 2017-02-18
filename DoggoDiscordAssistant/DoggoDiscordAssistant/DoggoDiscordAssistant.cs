using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace DoggoDiscordAssistant
{
    class DoggoDiscordAssistant : DiscordClient
    {
        public bool Debug { get; set; }

        public DoggoDiscordAssistant(Action<DiscordConfigBuilder> configFunc) : base (configFunc)
        {
            Logging.consoleLog("Connecting to server...", Logging.logType.System);
            Connect(3, 1000);
            MessageReceived += DoggoDiscordAssistant_MessageReceived;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            while (true)
            {
                AdminConsole.parseAdminInput(Console.ReadLine(), this);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Attempts to connect the bot to Discords Server.
        /// </summary>
        /// <param name="maxTries">The amount of tries the bot will attempt to connect to the server</param>
        /// <param name="timeout">The amount of time in milliseconds the bot will make in between each attempt</param>
        private void Connect(int maxTries, int timeout)
        {
            for (int tries = 0; tries < maxTries; tries++)
            {
                try
                {
                    Console.WriteLine();
                    Logging.consoleLog("attempting connection...[" + (tries + 1) + "/3]", Logging.logType.System);
                    Task task = Task.Run(async () => await Connect(Token.getToken, TokenType.Bot));
                    task.Wait();
                    Logging.consoleLog("Connected to server!", Logging.logType.System);
                    break;
                }
                catch (AggregateException e)
                {
                    Logging.consoleLog("Failed!", Logging.logType.Error);
                    foreach (Exception exception in e.InnerExceptions) Logging.consoleLog(exception.Message, Logging.logType.Error);
                    //If bot fails to connect to server, print error to screen and exit program
                    if (tries < (maxTries - 1)) System.Threading.Thread.Sleep(timeout);
                    else
                    {
                        Console.WriteLine();
                        Logging.consoleLog("Could not connect to server!", Logging.logType.Error);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void DoggoDiscordAssistant_MessageReceived(object sender, MessageEventArgs e)
        {
            CommandEngine.parseInput(e.Message.Text);
        }
    }
}
