using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DoggoDiscordAssistant
{
    class Server
    {
        public Discord.Server ServerAPI { get; }
        public string Welcome { get; }
        public string Leave { get; }
        //Initialize all available commands for the server
        public List<Command> AvailableCommands { get; set; } = new List<Command> {
            new Ping()
        };

        public Server(Discord.Server server)
        {
            /* Since discords server class is not inheritable due to design restrictions (internal constructor), 
            the discord server object will be encapsulated within this server class */
            ServerAPI = server;

            //Set default welcome message
            Welcome = "Welcome to " + ServerAPI.Name + "!";
        }

    }
}
