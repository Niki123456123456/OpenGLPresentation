using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGLPresentation
{
    public class OpenGlProgram
    {
        public int Id { get; }
        public OpenGlProgram(params Shader[] shaders)
        {
            int bufferId = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, bufferId);


            // Programm erstellen
            Id = GL.CreateProgram();

            // Shader erstellen
            List<int> shaderIds = new List<int>();
            foreach (Shader shader in shaders)
            {
                int shaderId = GL.CreateShader(shader.Type);
                shaderIds.Add(shaderId);
                GL.ShaderSource(shaderId, shader.SourceCode);
                GL.CompileShader(shaderId);
                GL.GetShader(shaderId, ShaderParameter.CompileStatus, out int code);
                if (code != (int)All.True)
                {
                    string infoLog = GL.GetShaderInfoLog(shaderId);
                    throw new Exception(infoLog);
                }
                GL.AttachShader(Id, shaderId);
            }
            

            // Programm linken
            GL.LinkProgram(Id);
            GL.GetProgram(Id, GetProgramParameterName.LinkStatus, out int programmCode);
            if (programmCode != (int)All.True)
            {
                throw new Exception("Error occurred whilst linking Program");
            }

            // Shader löschen
            foreach (int shaderId in shaderIds)
            {
                GL.DetachShader(Id, shaderId);
                GL.DeleteShader(shaderId);
            }
            
        }
    }
}
