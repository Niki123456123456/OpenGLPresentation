using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGLPresentation
{
    public delegate void DescribeVertexArray();
    public class VertexArray
    {
        public int Id { get; }
        public VertexArray(float[] vertices, DescribeVertexArray describeVertexArray)
        {
            // VertexArray erstellen
            Id = GL.GenVertexArray();
            GL.BindVertexArray(Id);

            // Zwischenspeicher erstellen
            int bufferId = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, bufferId);

            // Zwischenspeicher füllen
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            // Zwischenspeicher beschreiben
            describeVertexArray?.Invoke();
            
            // unbind
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

        }
    }
}
