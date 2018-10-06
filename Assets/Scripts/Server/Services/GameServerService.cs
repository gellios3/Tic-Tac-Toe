using System.Collections.Generic;
using System.Linq;
using Server.Interfaces;
using UnityEngine;
using UnityEngine.Networking;

namespace Server.Services
{
    public class GameServerService : IServer
    {
        /// <summary>
        /// Start server
        /// </summary>
        /// <param name="port"></param>
        public void StartServer(int port)
        {
            NetworkServer.Listen(port);
            Debug.Log("Start listening server on port " + port);
        }

        /// <summary>
        /// Restart server
        /// </summary>
        /// <param name="port"></param>
        public void Restart(int port)
        {
            Shutdown();
            StartServer(port);
        }

        /// <summary>
        /// Shutdown server
        /// </summary>
        public void Shutdown()
        {
            NetworkServer.Shutdown();
            Debug.Log("Stop server");
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="msgType"></param>
        /// <param name="msg"></param>
        public void Send(IEnumerable<int> connectionId, short msgType, MessageBase msg)
        {
            NetworkServer.SendToAll(msgType, msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handlers"></param>
        public void RegisterFeatureHandlers(IEnumerable<IServerFeature> handlers)
        {
            foreach (var handler in handlers)
            {
                foreach (var serverHandler in handler.Handlers())
                {
                    NetworkServer.RegisterHandler(serverHandler.MessageType, serverHandler.Handle);
                }
            }
        }

        /// <summary>
        /// Active connections
        /// </summary>
        public IEnumerable<int> ActiveConnections
        {
            get
            {
                var connections = NetworkServer.connections;
                var intConnection = connections.Select(p => p.connectionId);
                return intConnection;
            }
        }
    }
}