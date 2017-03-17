using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace DoggoDiscordAssistant.Commands
{
    class Config : Command
    {
        public override string Name { get; } = "Config";
        public override string Identifier { get; } = "config";
        public override string Description { get; } = "Used to configure the bot in various ways";
        public override string Help { get; } = "Command: >config";

        public override void Execute(Server server, Discord.Channel channel, Discord.User user, string parameter, Dictionary<string, string> flags)
        {
            foreach (KeyValuePair<string, string> flag in flags)
            {
                //Welcome Flag
                if (flag.Key == "welcome")
                {
                    server.Welcome = flag.Value;
                    channel.SendMessage("A new welcome message has been set for this server!");
                }
            }
        }
    }
}
