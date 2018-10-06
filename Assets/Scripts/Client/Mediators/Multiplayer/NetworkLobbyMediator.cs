using Client.Services.Multiplayer;
using Client.Signals.Multiplayer;
using Client.Views.Multiplayer;
using Mediators;
using Models;
using UnityEngine;

namespace Client.Mediators.Multiplayer
{
    public class NetworkLobbyMediator : TargetMediator<NetwokLobbyView>
    {
        /// <summary>
        /// Arena initialized signal
        /// </summary>
        [Inject]
        public ServerConnectedSignal ServerConnectedSignal { get; set; }

        /// <summary>
        /// Disconnected from server signal
        /// </summary>
        [Inject]
        public DisconnectedFromServerSignal DisconnectedFromServerSignal { get; set; }

        [Inject] public ShowLobbyPlayersSignal ShowLobbyPlayersSignal { get; set; }

        [Inject] public NetworkPlayerService NetworkPlayerService { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            ServerConnectedSignal.AddListener(() => { View.OnServerConnected(); });
            DisconnectedFromServerSignal.AddListener(() => { View.OnServerDisconnected(); });
            ShowLobbyPlayersSignal.AddListener(() => { View.ShowPlayersList(NetworkPlayerService.OnlinePlayers); });
        }
    }
}