using Client.Views.MainGame;
using Mediators;
using Services;

namespace Client.Mediators.MainGame
{
    public class NodeMediator : TargetMediator<NodeView>
    {
        /// <summary>
        /// Player service
        /// </summary>
        [Inject]
        public PlayerService PlayerService { get; set; }

        /// <summary>
        /// On register mediator
        /// </summary>
        public override void OnRegister()
        {
            View.OnClickNode += () =>
            {
                var icon = PlayerService.PlayerStatus ? View.Cube : View.Circle;
                if (View.HasShowIcon || icon == null) return;
                View.HasShowIcon = true;
                icon.SetActive(true);
                PlayerService.TogglePlayer();
                
                View.ParentColl.UpdateRowMap(View.CellNumber);
            };
        }
    }
}