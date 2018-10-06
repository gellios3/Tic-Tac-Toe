using strange.extensions.command.impl;
using Server.Services;
using Server.Signals;
using UnityEngine;

namespace Server.Commands
{
    public class CheckUsersConnectionCommand : Command
    {
        /// <summary>
        /// Network lobby service
        /// </summary>
        [Inject]
        public NetworkLobbyService NetworkLobbyService { get; set; }

        /// <summary>
        /// Send registred users signal
        /// </summary>
        [Inject]
        public RemoveLobbyPlayerSignal RemoveLobbyPlayerSignal { get; set; }


        /// <summary>
        /// Execute 
        /// </summary>
        public override void Execute()
        {
            foreach (var item in NetworkLobbyService.Players)
            {
                if (!(item.Ping > 0) || !(Time.time > item.Ping + 5)) continue;
                RemoveLobbyPlayerSignal.Dispatch(item.Id);
                NetworkLobbyService.Players.Remove(item);               
            }
        }
    }
}