using Boo.Lang;
using Models;

namespace Server.Services
{
    public class NetworkLobbyService
    {
        public List<MyNetworkPlayer> Players { get; } = new List<MyNetworkPlayer>();
    }
}