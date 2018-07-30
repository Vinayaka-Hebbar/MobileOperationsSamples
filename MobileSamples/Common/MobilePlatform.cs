using System;
using MobileSamples.Models;

namespace MobileSamples.Common
{
    public class MobilePlatform
    {
        public delegate void Renderer(Mobile mobile);

        public event Renderer Render;

        public IMobileUI MobileUI { get; set; }

        public void Run(Mobile mobile)
        {
            OnRender(mobile);
        }

        private void OnRender(Mobile mobile)
        {
            Render?.Invoke(mobile);
        }
    }
}
