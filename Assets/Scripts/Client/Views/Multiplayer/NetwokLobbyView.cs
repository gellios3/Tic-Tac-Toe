using System.Collections;
using System.Collections.Generic;
using Client.Signals.Multiplayer;
using Models;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using View.Multiplayer;

namespace Client.Views.Multiplayer
{
    public class NetwokLobbyView : EventView
    {
        /// <summary>
        /// Disconned player from server signal
        /// </summary>
        [Inject]
        public PingPlayerIdToServerSignal PingPlayerIdToServerSignal { get; set; }

        /// <summary>
        ///  Status view
        /// </summary>
        [SerializeField] private StatusView _serverStatus;

        /// <summary>
        ///  Status view
        /// </summary>
        [SerializeField] private GameObject _statusItem;

        private readonly List<GameObject> _statusViews = new List<GameObject>();

        protected override void Start()
        {
            StartCoroutine(SpawnLoop());
        }

        /// <summary>
        /// On server connected
        /// </summary>
        public void OnServerConnected()
        {
            _serverStatus.SetStatusOnline();
        }

        /// <summary>
        /// On disconect from server
        /// </summary>
        public void OnServerDisconnected()
        {
            _serverStatus.SetStatusOffline();
        }

        /// <summary>
        /// Show players list
        /// </summary>
        /// <param name="players"></param>
        public void ShowPlayersList(IEnumerable<MyNetworkPlayer> players)
        {
            RefreshStatusList();
            foreach (var item in players)
            {
                var statusView = Instantiate(_statusItem, new Vector2(), Quaternion.identity, transform);
                var statusItemView = _statusItem.GetComponent<StatusItemView>();
                statusItemView.InitPlayer(item);
                _statusViews.Add(statusView);
            }
        }

        /// <summary>
        /// Refresh status list
        /// </summary>
        private void RefreshStatusList()
        {
            foreach (var view in _statusViews)
            {
                Destroy(view);
            }

            _statusViews.Clear();
        }


        private IEnumerator SpawnLoop()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(5);
                PingPlayerIdToServerSignal.Dispatch();
            }
        }
    }
}