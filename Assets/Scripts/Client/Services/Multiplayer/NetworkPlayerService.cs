using System.Collections.Generic;
using Models;

namespace Client.Services.Multiplayer
{
    public class NetworkPlayerService
    {
        public MyNetworkPlayer NetworkLobbyPlayer { get; set; }

        public List<MyNetworkPlayer> OnlinePlayers { get; } = new List<MyNetworkPlayer>();
    }
}