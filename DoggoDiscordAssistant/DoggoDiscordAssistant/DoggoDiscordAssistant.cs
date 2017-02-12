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
        public DoggoDiscordAssistant(Action<DiscordConfigBuilder> configFunc) : base (configFunc)
        {
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
