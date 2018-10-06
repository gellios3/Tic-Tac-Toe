using Client.Signals;
using Client.Views.MainGame;
using Mediators;
using Services;

namespace Client.Mediators.MainGame
{
    public class CollMediator : TargetMediator<CollView>
    {
        /// <summary>
        /// Map service
        /// </summary>
        [Inject]
        public MapService MapService { get; set; }

        /// <summary>
        /// Player service
        /// </summary>
        [Inject]
        public PlayerService PlayerService { get; set; }

        /// <summary>
        /// On check game over signal
        /// </summary>
        [Inject]
        public CheckGameOverSignal CheckGameOverSignal { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.UpdateCell += pos =>
            {
                if (View.RowMap[pos] != 0) return;
                View.RowMap[pos] = PlayerService.PlayerStatus ? 1 : 2;
                MapService.UpdateCell(View.RowMap, View.CellPosition);
                CheckGameOverSignal.Dispatch();
            };
        }
    }
}