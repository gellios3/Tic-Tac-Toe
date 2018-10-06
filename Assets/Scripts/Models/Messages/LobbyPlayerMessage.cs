using UnityEngine.Networking;

namespace Models.Messages
{
    public class LobbyPlayerMessage  : MessageBase
    {
        public int Id;
        public string Name;
    }
}