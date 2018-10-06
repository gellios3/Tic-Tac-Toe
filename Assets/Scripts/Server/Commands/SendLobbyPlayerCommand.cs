using Models;
using Models.Messages;
using strange.extensions.command.impl;
using Server.Services;

namespace Server.Commands
{
    public class SendLobbyPlayerCommand : Command
    {
        /// <summary>
        /// Game serverService connector
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }

        /// <summary>
        /// Network player
        /// </summary>
        [Inject]
        public MyNetworkPlayer MyNetworkPlayer { get; set; }

        public override void Execute()
        {
            var message = new LobbyPlayerMessage
            {
                Id = MyNetworkPlayer.Id,
                Name = MyNetworkPlayer.Name
            };
            // Send lobby player to client
            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.SendLobbyPlayer, message);
        }
    }
}