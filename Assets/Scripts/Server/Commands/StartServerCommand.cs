using strange.extensions.command.impl;
using Server.Services;

namespace Server.Commands
{
    public class StartServerCommand : Command
    {
        /// <summary>
        /// Networking game server
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }

        /// <summary>
        /// Server port
        /// </summary>
        [Inject] public int ServerPort { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        public override void Execute()
        {
            GameServerService.StartServer(ServerPort);
        }
    }
}