using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Views.MainGame
{
    public class NodeView : EventView
    {
        [SerializeField] private int _cellNumber;
        public int CellNumber => _cellNumber;
        
        [SerializeField] private CollView _parentColl;
        public CollView ParentColl => _parentColl;
        
        [SerializeField] private Button _button;

        [SerializeField] private GameObject _cube;
        public GameObject Cube => _cube;

        [SerializeField] private GameObject _circle;
        public GameObject Circle => _circle;

        private GameObject _icon;

        public bool HasShowIcon { get; set; }

        public Action OnClickNode;

        protected override void Start()
        {
            _button.onClick.AddListener(() =>
            {
                OnClickNode?.Invoke();
            });
        }
    }
}