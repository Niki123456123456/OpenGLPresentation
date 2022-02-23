using System;
using System.Collections.Generic;
using System.Text;

namespace lesson0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Window window = new Window())
            {
                window.Run();
            }
        }
    }
}
