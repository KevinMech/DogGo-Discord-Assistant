using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    abstract class Command
    {
        public abstract string Name { get; }
        public abstract string Identifier { get; }
        public abstract string Description { get; }
        public abstract string Help { get; }

        public abstract void Execute(Discord.Channel channel);

    }
}
