using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace lesson0
{
    public class Window : GameWindow
    {
        public Window() : base(1000, 1000, GraphicsMode.Default, "Test Window", GameWindowFlags.FixedWindow)
        {
           
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // Todo setze den Hintergrund auf Rot

            SwapBuffers();
        }
    }
}
