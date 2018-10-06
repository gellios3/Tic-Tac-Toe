using Client.Commands;
using Client.Commands.Multiplayer;
using Client.Handlers;
using Client.Mediators.MainGame;
using Client.Mediators.Multiplayer;
using Client.Services.Multiplayer;
using Client.Signals;
using Client.Signals.Multiplayer;
using Client.Views.MainGame;
using Client.Views.Multiplayer;
using Handlers;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using UnityEngine;

namespace Client.Contexts
{
    public class MainGameContext : MVCSContext
    {
        public MainGameContext(MonoBehaviour view) : base(view)
        {
            _instance = this;
        }

        public MainGameContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
            _instance = this;
        }

        private static MainGameContext _instance;

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

        /// <inheritdoc />
        /// <summary>
        /// Override Start so that we can fire the StartSignal 
        /// </summary>
        /// <returns></returns>
        public override IContext Start()
        {
            base.Start();
            var startSignal = injectionBinder.GetInstance<ConnectToServerSignal>();
            startSignal.Dispatch();
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// Override Bindings map
        /// </summary>
        protected override void mapBindings()
        {
            // init Signals
            injectionBinder.Bind<ServerConnectedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<DisconnectedFromServerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<PingPlayerIdToServerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<GetEnemyTurnSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowLobbyPlayersSignal>().ToSingleton();

            // Bind Handlers
            injectionBinder.Bind<GetEnemyTurnHandler>().ToSingleton().CrossContext();
            injectionBinder.Bind<GetLobbyPlayerHandler>().ToSingleton().CrossContext();
            injectionBinder.Bind<RemoveLobbyPlayerHandler>().ToSingleton().CrossContext();

            // Init commands
            commandBinder.Bind<CheckGameOverSignal>().To<CheckGameOverCommand>();
            commandBinder.Bind<ConnectToServerSignal>().To<ConectToServerCommand>();
            commandBinder.Bind<PingPlayerIdToServerSignal>().To<PingPlayerIdToServerCommand>();
            commandBinder.Bind<ServerConnectedSignal>().To<ServerConectedCommand>().Once();

            // Init services
            injectionBinder.Bind<ServerConnectorService>().ToSingleton().CrossContext();
            injectionBinder.Bind<MapService>().ToSingleton();

            // Init mediators
            mediationBinder.Bind<CollView>().To<CollMediator>();
            mediationBinder.Bind<NodeView>().To<NodeMediator>();
            mediationBinder.Bind<NetwokLobbyView>().To<NetworkLobbyMediator>();
            mediationBinder.Bind<StatusItemView>().To<StatusItemMediator>();
        }
    }
}