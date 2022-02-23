using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGLPresentation
{
    public class Window : GameWindow
    {
        public Window() : base(1000, 1000, GraphicsMode.Default, "Test Window", GameWindowFlags.Default)
        {
            // Todo setze den Hintergrund auf Rot
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(1f, 0f, 0f, 1f);
        }
    }
}
