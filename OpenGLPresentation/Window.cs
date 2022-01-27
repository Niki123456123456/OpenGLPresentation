using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGLPresentation
{
    public class Window : GameWindow
    {
        private OpenGlProgram program;
        private VertexArray vertexArray;
        public Window() : base(1000, 1000, GraphicsMode.Default, "Test Window", GameWindowFlags.Default)
        {
            
        }

        protected override void OnLoad(EventArgs eventArgs)
        {
            VertexShader vertexShader = new VertexShader(@"
#version 140
in vec2 aPosition;

void main()
{
    gl_Position = vec4(aPosition, 1.0, 1.0);
}");

            FragmentShader fragmentShader = new FragmentShader(@"
#version 140
precision highp float;

void main()
{
    vec2 position = gl_FragCoord.xy / 1000.0;
    gl_FragColor = vec4(position, 1.0, 1.0);
}");

            program = new OpenGlProgram(vertexShader, fragmentShader);

            vertexArray = new VertexArray(new []{
            -1f, -1f,  
             1f, -1f, 
             -1f,  1f,

             -1f, 1f,
             1f, -1f,
             1f, 1f,
        }, () => {
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        });

        }

        protected override void OnRenderFrame(FrameEventArgs frameEventArgs)
        {
            // lösche Farben aus Zwischenspeicher
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.UseProgram(program.Id);
            GL.BindVertexArray(vertexArray.Id);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);

            // zeige Bild
            SwapBuffers();
        }
    }
}
