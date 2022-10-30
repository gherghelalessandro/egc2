using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Mod3d
{
    class Program
    {
        

        [STAThread]
        static void Main(string[] args)
        {
            using (Window2d example = new Window2d())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
