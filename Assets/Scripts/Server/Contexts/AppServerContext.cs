using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Server.Commands;
using Server.Handlers;
using Server.Mediators;
using Server.Services;
using Server.Signals;
using Server.Views;
using UnityEngine;

namespace Server.Contexts
{
    public class AppServerContext : MVCSContext
    {
        public AppServerContext(MonoBehaviour view) : base(view)
        {
            _instance = this;
        }

        public AppServerContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
            _instance = this;
        }

        private static AppServerContext _instance;

        public static T Get<T>()
        {
            return _instance.injectionBinder.GetInstance<T>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        /// </summary>
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        /// <summary>
        /// Override Start so that we can fire the StartSignal 
        /// </summary>
        /// <returns></returns>
        public override IContext Start()
        {
            base.Start();

            var startSignal = injectionBinder.GetInstance<StartListeningServerSignal>();
            startSignal.Dispatch();

            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// Ovverade Bindings map
        /// </summary>
        protected override void mapBindings()
        {
            // Bind Signals
            injectionBinder.Bind<ServerErrorSignal>().ToSingleton();

            // Bind Services
            injectionBinder.Bind<GameServerService>().ToSingleton();
            injectionBinder.Bind<NetworkLobbyService>().ToSingleton();
            
            // Bind Handlers
            injectionBinder.Bind<PlayerMessageHandler>().ToSingleton();
            injectionBinder.Bind<PingPlayerHandler>().ToSingleton();

            // Bind Commands
            commandBinder.Bind<StartListeningServerSignal>().To<StartListeningCommand>();
            commandBinder.Bind<SendLobbyPlayerSignal>().To<SendLobbyPlayerCommand>();
            commandBinder.Bind<RemoveLobbyPlayerSignal>().To<RemoveLobbyPlayerCommand>();
            commandBinder.Bind<StartServerSignal>().To<StartServerCommand>();
            commandBinder.Bind<ServerConnectedSignal>().To<ServerConnectedCommand>();
            commandBinder.Bind<DisconnectSignal>().To<DisconectFromServerCommand>();
            commandBinder.Bind<CheckUsersConnectionSignal>().To<CheckUsersConnectionCommand>();

            // Bind Views   
            mediationBinder.Bind<ServerView>().To<ServerViewMediator>();
            mediationBinder.Bind<ChatView>().To<ChatViewMediator>();
        }
    }
}