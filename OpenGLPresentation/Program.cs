using System;

namespace OpenGLPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleExtension.Hide();
            using (Window window = new Window())
            {
                window.Run();
            }
        }
    }
}
