using Client.Signals;
using strange.extensions.command.impl;
using Services;

namespace Client.Commands
{
    public class CheckGameOverCommand : Command
    {
        /// <summary>
        /// Map service
        /// </summary>
        [Inject]
        public MapService MapService { get; set; }

        /// <summary>
        /// Game over signal
        /// </summary>
        [Inject]
        public GameOverSignal GameOverSignal { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        public override void Execute()
        {
            if (!CheckGameOver()) return;
            GameOverSignal.Dispatch();
        }

        /// <summary>
        /// Check game over
        /// </summary>
        /// <returns></returns>
        private bool CheckGameOver()
        {
            // Check columns
            for (var x = 0; x < MapService.Map.Length; x++)
            {
                if (MapService.IsAllFieldsTheSame(x, 0, 0, 1))
                {
                    return true;
                }
            }

            // Check rows
            for (var y = 0; y < MapService.Map.Length; y++)
            {
                if (MapService.IsAllFieldsTheSame(0, y, 1, 0))
                {
                    return true;
                }
            }

            // Check diagonals
            return MapService.IsAllFieldsTheSame(0, 0, 1, 1) || MapService.IsAllFieldsTheSame(2, 0, -1, 1);
        }
    }
}