using Client.Views.Multiplayer;
using Mediators;
using UnityEngine;

namespace Client.Mediators.Multiplayer
{
    public class StatusItemMediator : TargetMediator<StatusItemView>
    {
        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            Debug.Log("StatusItemMediator");
        }
    }
}