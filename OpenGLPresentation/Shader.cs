using OpenTK.Graphics.OpenGL4;

namespace OpenGLPresentation
{
    public abstract class Shader
    {
        public string SourceCode { get; protected set; }
        public abstract ShaderType Type { get; }
    }

    public class FragmentShader : Shader
    {
        public FragmentShader(string sourceCode)
        {
            SourceCode = sourceCode;
        }
        public override ShaderType Type => ShaderType.FragmentShader;
    }

    public class VertexShader : Shader
    {
        public VertexShader(string sourceCode)
        {
            SourceCode = sourceCode;
        }
        public override ShaderType Type => ShaderType.VertexShader;
    }
}
