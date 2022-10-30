using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace test1opentk
{
    public class Program:GameWindow
    {
        float x=0, y=0;
        int text;
        public Program():base(800,600)
        {
            KeyDown +=Keyboard_KeyDown;
            GL.Enable(EnableCap.Texture2D);

        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
            text = Draw.loadTexture("C:\\Users\\Kryss\\Desktop\\image.jpg");

        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            //determina marimea axei de cordonate x,y;
            GL.Ortho(-5.0, 5.0, -5.0, 5.0, 0.0, 4.0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            /*
            if(mouse.X!=0)
            {
                GL.Rotate(10, 0,0, mouse.X);
            }
            */

            if (keyboard[Key.Left])
                x-=0.1f;
            if (keyboard[Key.Right])
                x += 0.1f;
            if (keyboard[Key.Up])
                y += 0.1f;
            if (keyboard[Key.Down])
                y -= 0.1f;
           
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.BindTexture(TextureTarget.Texture2D,text);

            GL.Begin(PrimitiveType.Polygon);
            
            
            GL.Vertex2(x + 1, y + 1);
            GL.TexCoord2(1, 1);
            
            GL.Vertex2(x + 1, y - 1);
            GL.TexCoord2(1, 0);
       
            GL.Vertex2(x - 1, y - 1);
            GL.TexCoord2(0, 0);
          
            GL.Vertex2(x - 1, y + 1);
            GL.TexCoord2(0, 1);
            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (Program example = new Program())
            {
                example.Run(30.0, 0.0);
            }

        }
    }
}
