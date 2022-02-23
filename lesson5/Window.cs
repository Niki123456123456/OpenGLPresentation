using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Platform.Windows;

namespace lesson0
{
    public class Window : GameWindow
    {
        private float _time = 0.0f;
        private readonly int _program;
        private readonly int _buffer;
        public Window() : base(1000, 1000, GraphicsMode.Default, "Test Window", GameWindowFlags.FixedWindow)
        {
            _program = CreateProgram();
            _buffer = CreateBuffer();
        }

        private int CreateProgram()
        {
            int program = GL.CreateProgram();
            GL.AttachShader(program, CreateVertexShader());
            GL.AttachShader(program, CreateFragmentShader());
            GL.LinkProgram(program);
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out int linkStatus);
            if (linkStatus != 1)
            {
                Console.WriteLine($"linking failed: {GL.GetProgramInfoLog(program)}");
            }
            else
            {
                Console.WriteLine("linking succeed");
            }

            return program;
        }
        private int CreateVertexShader()
        {
            string vertexShaderSource = File.ReadAllText("shader.vert");
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);
            GL.GetShader(vertexShader, ShaderParameter.CompileStatus, out int compileStatus);
            if (compileStatus != 1)
            {
                Console.WriteLine($"compiling failed: {GL.GetShaderInfoLog(vertexShader)}");
            }
            else
            {
                Console.WriteLine("compiling succeed");
            }

            return vertexShader;
        }
        private int CreateFragmentShader()
        {
            string fragmentShaderSource = File.ReadAllText("shader.frag");
            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);
            GL.GetShader(fragmentShader, ShaderParameter.CompileStatus, out int compileStatus);
            if (compileStatus != 1)
            {
                Console.WriteLine($"compiling failed: {GL.GetShaderInfoLog(fragmentShader)}");
            }
            else
            {
                Console.WriteLine("compiling succeed");
            }

            return fragmentShader;
        }

        private int CreateBuffer()
        {
            float[] positions = 
            {
                1.0f, 1.0f,
                -1.0f, 1.0f,
                1.0f, -1.0f,
                -1.0f, -1.0f,
            };
            var buffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);
            GL.BufferData(BufferTarget.ArrayBuffer, positions.Length * sizeof(float), positions, BufferUsageHint.StaticDraw);
            return buffer;
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // Todo ändere die Geschwindigkeit der Animation
            // clear
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );

            // bind
            GL.BindBuffer(BufferTarget.ArrayBuffer, _buffer);
            GL.VertexAttribPointer(GL.GetAttribLocation(_program, "position"), 2, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexArrayAttrib(0, GL.GetAttribLocation(_program, "position"));
            GL.UseProgram(_program);
            GL.Uniform2(GL.GetUniformLocation(_program, "size"), (float) Width, (float) Height);
            GL.Uniform1(GL.GetUniformLocation(_program, "time"), _time);
            _time += 0.01f;

            GL.DrawArrays(PrimitiveType.TriangleStrip, 0, 4);

            SwapBuffers();
        }
    }
}
