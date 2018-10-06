using Mediators;
using Server.Signals;
using Server.Views;


/// <summary>
/// Server view mediator
/// </summary>
public class ServerViewMediator : TargetMediator<ServerView>
{
    /// <summary>
    /// Server connected signal
    /// </summary>
    [Inject]
    public ServerConnectedSignal ServerConnectedSignal { get; set; }

    /// <summary>
    /// Disconnect server signal
    /// </summary>
    [Inject]
    public DisconnectSignal DisconnectSignal { get; set; }

    /// <summary>
    /// On sever error 
    /// </summary>
    [Inject]
    public ServerErrorSignal ServerErrorSignal { get; set; }

    /// <summary>
    /// On register
    /// </summary>
    public override void OnRegister()
    {
        ServerConnectedSignal.AddListener(success =>
        {
            View.ChangeStatus(success ? "Connected" : "Connected Error!");
        });
        DisconnectSignal.AddListener(success =>
        {
            View.ChangeStatus(success ? "Disconnected" : "Disconnected Error!");
        });
        ServerErrorSignal.AddListener(View.OnGameServerError);
    }
}