using UnityEngine.Networking;

namespace Server.Interfaces
{
    public interface IServerHandler
    {
        short MessageType { get; }
        void Handle(NetworkMessage message);
    }
}