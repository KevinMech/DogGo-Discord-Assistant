using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggoDiscordAssistant
{
    abstract class Command
    {
        public abstract string CommandName { get; set; }
        public abstract string Description { get; set; }
        public abstract string Help { get; set; }

        public abstract void Execute();
    }
}
