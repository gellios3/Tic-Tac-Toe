using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Client.Views.MainGame
{
    public class CollView : EventView
    {
        /// <summary>
        /// Position
        /// </summary>
        [SerializeField] private int _cellPosition;
        
        public int CellPosition => _cellPosition;

        /// <summary>
        /// Update cell action
        /// </summary>
        public Action<int> UpdateCell;

        /// <summary>
        /// Row Map
        /// </summary>
        public int[] RowMap { get; set; } = {0, 0, 0};

       
        /// <summary>
        /// Update Row Map
        /// </summary>
        /// <param name="position"></param>
        public void UpdateRowMap(int position)
        {
            UpdateCell?.Invoke(position);
        }
    }
}