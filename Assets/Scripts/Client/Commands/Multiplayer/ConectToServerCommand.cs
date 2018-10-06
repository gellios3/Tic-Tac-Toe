using Client.Services.Multiplayer;
using strange.extensions.command.impl;

namespace Client.Commands.Multiplayer
{
    public class ConectToServerCommand : Command
    {
        /// <summary>
        /// Server url
        /// </summary>
        private const string Url = "localhost";

        /// <summary>
        /// Server port
        /// </summary>
        private const int Port = 45555;

        /// <summary>
        /// Server connector service
        /// </summary>
        [Inject]
        public ServerConnectorService ServerConnectorService { get; set; }

        /// <summary>
        /// Execute connect to server
        /// </summary>
        public override void Execute()
        {
            ServerConnectorService.Connect(Url, Port);
        }
    }
}