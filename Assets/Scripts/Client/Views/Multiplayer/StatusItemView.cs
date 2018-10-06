using Models;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;
using View.Multiplayer;

namespace Client.Views.Multiplayer
{
    public class StatusItemView : EventView
    {
        [SerializeField] private Text _title;
        [SerializeField] private MyNetworkPlayer _networkLobbyPlayer;
        [SerializeField] private StatusView _status;

        public void InitPlayer(MyNetworkPlayer lobbyPlayer)
        {
            _networkLobbyPlayer = lobbyPlayer;
            _title.text = lobbyPlayer.Name;
            _status.SetStatusOnline();
        }
    }
}