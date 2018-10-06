using strange.extensions.command.impl;
using UnityEngine;

namespace Server.Commands
{
    public class DisconectFromServerCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("DisconectFromServerCommand");
        }
    }
}