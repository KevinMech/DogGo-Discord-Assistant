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
            DoggoDiscordAssistant doggodiscordassistant = new DoggoDiscordAssistant(metadata =>
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
