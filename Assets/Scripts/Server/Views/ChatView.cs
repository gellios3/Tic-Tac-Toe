using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using Server.Handlers;
using Server.Interfaces;
using Server.Signals;
using UnityEngine;

namespace Server.Views
{
    public class ChatView : EventView, IServerFeature
    {
        [Inject] public PlayerMessageHandler PlayerMessageHandler { get; set; }
        [Inject] public PingPlayerHandler PingPlayerHandler { get; set; }
        [Inject] public CheckUsersConnectionSignal CheckUsersConnectionSignal { get; set; }

        private void Awake()
        {
            StartCoroutine(SpawnLoop());
        }

        /// <summary>
        /// Handlers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IServerHandler> Handlers()
        {
            return new List<IServerHandler>
            {
                PlayerMessageHandler,
                PingPlayerHandler
            };
        }
        
        private IEnumerator SpawnLoop()
        {
            while (enabled)
            {
                yield return new WaitForSeconds (5);
                CheckUsersConnectionSignal.Dispatch();            
            }
        }
    }
}