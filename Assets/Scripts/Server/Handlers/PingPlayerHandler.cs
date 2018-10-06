using Models;
using Models.Messages;
using Server.Interfaces;
using Server.Services;
using UnityEngine;
using UnityEngine.Networking;

namespace Server.Handlers
{
    public class PingPlayerHandler : IServerHandler
    {
        /// <summary>
        /// Message Type
        /// </summary>
        public short MessageType => MsgStruct.SendPlayerID;

        /// <summary>
        /// Network lobby service
        /// </summary>
        [Inject] public NetworkLobbyService NetworkLobbyService { get; set; }

        /// <summary>
        ///  Message Handle
        /// </summary>
        /// <param name="message"></param>
        public void Handle(NetworkMessage message)
        {
            var pingPlayerMessage = message.ReadMessage<PingPlayerMessage>();
            if (pingPlayerMessage == null) return;
            for (var i = 0; i < NetworkLobbyService.Players.Count; i++)
            {
                if (NetworkLobbyService.Players[i].Id == pingPlayerMessage.Id)
                {
                    NetworkLobbyService.Players[i] = new MyNetworkPlayer
                    {
                        Id = pingPlayerMessage.Id,
                        Name = NetworkLobbyService.Players[i].Name,
                        Ping = Time.time
                    };
                }
            }
         
        }
    }
}