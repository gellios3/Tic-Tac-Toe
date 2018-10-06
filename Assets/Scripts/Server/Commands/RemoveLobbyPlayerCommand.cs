using Models;
using Models.Messages;
using strange.extensions.command.impl;
using Server.Services;

namespace Server.Commands
{
    public class RemoveLobbyPlayerCommand : Command
    {
        
        /// <summary>
        /// Game serverService connector
        /// </summary>
        [Inject]
        public GameServerService GameServerService { get; set; }
        
        [Inject] public int PlayerId { get; set; }
        
        public override void Execute()
        {
            var message = new PingPlayerMessage
            {
                Id = PlayerId
            };
            // Send lobby player to client
            GameServerService.Send(GameServerService.ActiveConnections, MsgStruct.RemoveLobbyPlayer, message);
        }
    }
}