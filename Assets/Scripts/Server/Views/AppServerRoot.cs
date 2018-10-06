using strange.extensions.context.impl;

namespace Server.Contexts
{
    public class AppServerRoot : ContextView
    {
        private void Awake()
        {
            context = new AppServerContext(this);
        }
    }
}