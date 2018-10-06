using Client.Services.Multiplayer;
using Models;
using Models.Messages;
using strange.extensions.command.impl;
using UnityEngine;

namespace Client.Commands.Multiplayer
{
    public class PingPlayerIdToServerCommand : Command
    {
        /// <summary>
        /// Server connector service
        /// </summary>
        [Inject]
        public ServerConnectorService ServerConnectorService { get; set; }

        /// <summary>
        /// Network player service
        /// </summary>
        [Inject]
        public NetworkPlayerService NetworkPlayerService { get; set; }

        /// <summary>
        /// Execute connect to server
        /// </summary>
        public override void Execute()
        {
            ServerConnectorService.Send(MsgStruct.SendPlayerID, new PingPlayerMessage
            {
                Id = NetworkPlayerService.NetworkLobbyPlayer.Id
            });
        }
    }
}