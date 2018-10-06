namespace Services
{
    public class PlayerService
    {
        /// <summary>
        /// Player Status
        /// </summary>
        public bool PlayerStatus { get; private set; } = true;

        /// <summary>
        /// Toggle player
        /// </summary>
        public void TogglePlayer()
        {
            PlayerStatus = !PlayerStatus;
        }
    }
}