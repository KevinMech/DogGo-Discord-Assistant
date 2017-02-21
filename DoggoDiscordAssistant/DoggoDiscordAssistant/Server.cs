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
