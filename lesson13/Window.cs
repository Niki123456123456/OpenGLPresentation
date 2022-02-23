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
        private float a = 0.0f;
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
                // Front face
                -1.0f, -1.0f,  1.0f,    1.0f,  1.0f,  1.0f,  1.0f,
                1.0f, -1.0f,  1.0f,    1.0f,  1.0f,  1.0f,  1.0f,
                1.0f,  1.0f,  1.0f,    1.0f,  1.0f,  1.0f,  1.0f,

                -1.0f, -1.0f,  1.0f,    1.0f,  1.0f,  1.0f,  1.0f,
                1.0f,  1.0f,  1.0f,    1.0f,  1.0f,  1.0f,  1.0f,
                -1.0f,  1.0f,  1.0f,    1.0f,  1.0f,  1.0f,  1.0f,

                // Back face
                -1.0f, -1.0f, -1.0f,     1.0f,  0.0f,  0.0f,  1.0f,
                -1.0f,  1.0f, -1.0f,     1.0f,  0.0f,  0.0f,  1.0f,
                1.0f,  1.0f, -1.0f,     1.0f,  0.0f,  0.0f,  1.0f,

                -1.0f, -1.0f, -1.0f,     1.0f,  0.0f,  0.0f,  1.0f,
                1.0f,  1.0f, -1.0f,     1.0f,  0.0f,  0.0f,  1.0f,
                1.0f, -1.0f, -1.0f,     1.0f,  0.0f,  0.0f,  1.0f,

                // Top face
                -1.0f,  1.0f, -1.0f,   0.0f,  1.0f,  0.0f,  1.0f,
                -1.0f,  1.0f,  1.0f,   0.0f,  1.0f,  0.0f,  1.0f,
                1.0f,  1.0f,  1.0f,   0.0f,  1.0f,  0.0f,  1.0f,

                -1.0f,  1.0f, -1.0f,   0.0f,  1.0f,  0.0f,  1.0f,
                1.0f,  1.0f,  1.0f,   0.0f,  1.0f,  0.0f,  1.0f,
                1.0f,  1.0f, -1.0f,   0.0f,  1.0f,  0.0f,  1.0f,

                // Bottom face
                -1.0f, -1.0f, -1.0f,   0.0f,  0.0f,  1.0f,  1.0f,
                1.0f, -1.0f, -1.0f,   0.0f,  0.0f,  1.0f,  1.0f,
                1.0f, -1.0f,  1.0f,   0.0f,  0.0f,  1.0f,  1.0f,

                -1.0f, -1.0f, -1.0f,   0.0f,  0.0f,  1.0f,  1.0f,
                1.0f, -1.0f,  1.0f,   0.0f,  0.0f,  1.0f,  1.0f,
                -1.0f, -1.0f,  1.0f,   0.0f,  0.0f,  1.0f,  1.0f,

                // Right face
                1.0f, -1.0f, -1.0f,   1.0f,  1.0f,  0.0f,  1.0f,
                1.0f,  1.0f, -1.0f,   1.0f,  1.0f,  0.0f,  1.0f,
                1.0f,  1.0f,  1.0f,   1.0f,  1.0f,  0.0f,  1.0f,

                1.0f, -1.0f, -1.0f,   1.0f,  1.0f,  0.0f,  1.0f,
                1.0f,  1.0f,  1.0f,   1.0f,  1.0f,  0.0f,  1.0f,
                1.0f, -1.0f,  1.0f,   1.0f,  1.0f,  0.0f,  1.0f,

                // Left face
                -1.0f, -1.0f, -1.0f,   1.0f,  0.0f,  1.0f,  1.0f,
                -1.0f, -1.0f,  1.0f,   1.0f,  0.0f,  1.0f,  1.0f,
                -1.0f,  1.0f,  1.0f,   1.0f,  0.0f,  1.0f,  1.0f,

                -1.0f, -1.0f, -1.0f,   1.0f,  0.0f,  1.0f,  1.0f,
                -1.0f,  1.0f,  1.0f,   1.0f,  0.0f,  1.0f,  1.0f,
                -1.0f,  1.0f, -1.0f,   1.0f,  0.0f,  1.0f,  1.0f,
            };
            var buffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);
            GL.BufferData(BufferTarget.ArrayBuffer, positions.Length * sizeof(float), positions, BufferUsageHint.StaticDraw);
            return buffer;
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // clear
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );

            // bind
            GL.BindBuffer(BufferTarget.ArrayBuffer, _buffer);
            GL.VertexAttribPointer(GL.GetAttribLocation(_program, "position"), 3, VertexAttribPointerType.Float, false, 28, 0);
            GL.VertexAttribPointer(GL.GetAttribLocation(_program, "color"), 4, VertexAttribPointerType.Float, false, 28, 12);
            GL.EnableVertexArrayAttrib(0, GL.GetAttribLocation(_program, "position"));
            GL.EnableVertexArrayAttrib(0, GL.GetAttribLocation(_program, "color"));
            GL.UseProgram(_program);

            float fieldOfView = 45f * Convert.ToSingle(Math.PI)  / 180f;   // 45 grad in radiant
            float aspect =(float) Width / (float) Height;
            float zNear = 0.1f;
            float zFar = 100f;
            Matrix4 projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(fieldOfView, aspect, zNear, zFar);
            GL.UniformMatrix4(GL.GetUniformLocation(_program, "projectionMatrix"), false, ref projectionMatrix);

            Matrix4 modelMatrix = Matrix4.CreateTranslation(0.0f, 0.0f, -6.0f);
            modelMatrix = Matrix4.CreateRotationX(a) * Matrix4.CreateRotationY(a) * Matrix4.CreateRotationZ(a) * modelMatrix;
            a += 0.001f;
            GL.UniformMatrix4(GL.GetUniformLocation(_program, "modelMatrix"), false, ref modelMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            SwapBuffers();
        }
    }
}
