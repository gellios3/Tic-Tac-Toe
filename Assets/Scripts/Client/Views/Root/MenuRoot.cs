using Client.Contexts;
using strange.extensions.context.impl;

namespace Client.Views.Root
{
    public class MenuRoot : ContextView
    {
        private void Awake()
        {
            context = new MenuContext(this);
        }
    }
}