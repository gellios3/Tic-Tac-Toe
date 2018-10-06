using System.Collections.Generic;
using Server.Interfaces;
using Server.Services;
using Server.Views;

namespace Server.Mediators
{
    /// <summary>
    /// Chat view mediator
    /// </summary>
    public class ChatViewMediator : TargetMediator<ChatView>
    {
        [Inject] public GameServerService GameServerServiceConnector { get; set; }

        public override void OnRegister()
        {
            GameServerServiceConnector.RegisterFeatureHandlers(new List<IServerFeature> {View});
        }
    }
}