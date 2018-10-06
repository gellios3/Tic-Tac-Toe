using Client.Services.Multiplayer;
using Models;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.Networking;

namespace Client.Commands.Multiplayer
{
    public class StartOnlineGameCommand : Command
    {
        [Inject] public string PlayerName { get; set; }

        /// <summary>
        /// Network player service
        /// </summary>
        [Inject]
        public NetworkPlayerService NetworkPlayerService { get; set; }

        /// <summary>
        /// Execute event add log
        /// </summary>
        public override void Execute()
        {
            Debug.Log("StartOnlineGameCommand " + PlayerName);

            NetworkPlayerService.NetworkLobbyPlayer = new MyNetworkPlayer
            {
                Id = Random.Range(0, 1000),
                Name = PlayerName
            };
        }
    }
}