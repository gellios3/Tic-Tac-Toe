using System.Collections.Generic;

namespace Server.Interfaces
{
    public interface IServerFeature
    {
        IEnumerable<IServerHandler> Handlers();
    }
}