using Client.Signals;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Client.Views.MainGame
{
    public class GamePanelView : EventView
    {
        [SerializeField] private GameObject _parent;
        
        /// <summary>
        /// Game service
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }

        protected override void Start()
        {
            GameOverSignal.AddListener(() => { Destroy(_parent); });
        }
    }
}