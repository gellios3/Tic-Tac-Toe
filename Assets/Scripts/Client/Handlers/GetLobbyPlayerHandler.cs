using Client.Services.Multiplayer;
using Client.Signals.Multiplayer;
using Interfaces;
using Models;
using Models.Multiplayer.Messages;
using UnityEngine;
using UnityEngine.Networking;

namespace Client.Handlers
{
    public class GetLobbyPlayerHandler : IServerMessageHandler
    {
        public short MessageType => MsgStruct.SendLobbyPlayer;

        [Inject] public NetworkPlayerService NetworkPlayerService { get; set; }
        [Inject] public ShowLobbyPlayersSignal ShowLobbyPlayersSignal { get; set; }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="msg"></param>
        public void Handle(NetworkMessage msg)
        {
            var lobbyPlayerMessage = msg.ReadMessage<LobbyPlayerMessage>();
            if (lobbyPlayerMessage == null) return;
            var item = new MyNetworkPlayer
            {
                Id = lobbyPlayerMessage.Id,
                Name = lobbyPlayerMessage.Name
            };
            var index = NetworkPlayerService.OnlinePlayers.IndexOf(item);
            if (index == -1)
            {
                NetworkPlayerService.OnlinePlayers.Add(item);
            }
            else
            {
                NetworkPlayerService.OnlinePlayers[index] = item;
            }

            ShowLobbyPlayersSignal.Dispatch();
        }
    }
}