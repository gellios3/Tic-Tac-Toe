using System;
using System.Collections.Generic;
using Server.Signals;
using UnityEngine.Networking;

namespace Server.Interfaces
{
    public interface IServer
    {
        void StartServer(int port);
        void Restart(int port);
        void Shutdown();

        void Send(IEnumerable<int> connectionId, short msgType, MessageBase msg);
        void RegisterFeatureHandlers(IEnumerable<IServerFeature> handlers);

        IEnumerable<int> ActiveConnections { get; }
    }
}