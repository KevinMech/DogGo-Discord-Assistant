using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    class Ping : Command
    {
        public override string Name { get; } = "Ping";
        public override string Identifier { get; } = "ping";
        public override string Description { get; } = "Returns a message saying 'Pong!' along with the time it took to execute";
        public override string Help { get; } = "Command: >ping";

        public override void Execute(Server server, Discord.Channel channel, Discord.User user, string parameter, Dictionary<string, string> flags)
        {
            channel.SendMessage("Pong!");
        }
    }
}
