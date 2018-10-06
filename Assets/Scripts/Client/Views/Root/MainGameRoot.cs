using Client.Contexts;
using strange.extensions.context.impl;
using UnityEngine;

namespace Client.Views.Root
{
    public class MainGameRoot : ContextView
    {
                
        private void Awake()
        {
            context = new MainGameContext(this);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}