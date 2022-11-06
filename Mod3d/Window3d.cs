using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Mod3d
{
    public class Window3d : GameWindow
    {
        private const int XYZ_SIZE = 75;
        Triangle t = new Triangle("C:\\Users\\Kryss\\source\\repos\\egc2\\Mod3d\\cordonate.txt");
        private KeyboardState previousKeyboard;
        Camera cam;
        Vector3[] v;
        int lasttimex;
        bool first=true;

        public Window3d() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            v = new Vector3[2];
            v[0] = new Vector3(10,10,10);
            v[1] = new Vector3(0, 1, 0);
            cam = new Camera(v[0], v[1]);
            Console.WriteLine("OpenGl versiunea: " + GL.GetString(StringName.Version));
            Title = "OpenGl versiunea: " + GL.GetString(StringName.Version) + " (mod imediat)";

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Gray);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            cam.setmatrix();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
   

            if (keyboard[Key.Escape])
            {
                Exit();
            }
            //lab 3 ex 9
            if (keyboard[Key.R] && !previousKeyboard[Key.R])
            {
                t.red = true;
                t.blue = false;
                t.green = false;
                Console.WriteLine("Red mode");
            }
            if (keyboard[Key.B] && !previousKeyboard[Key.B])
            {
                t.blue = true;
                t.green = false;
                t.red = false;
                Console.WriteLine("Blue mode");
            }
            if (keyboard[Key.G] && !previousKeyboard[Key.G])
            {
                t.blue = false;
                t.green = true;
                t.red = false;
                Console.WriteLine("Green mode");
            }
            if (keyboard[Key.Up])
            {
                t.brightenup();
            }
            if (keyboard[Key.Down])
            {
                t.brightendown();
            }
            /*
            if(keyboard[Key.W])
            {
                cam.move(1);
            }
            if (keyboard[Key.S])
            {
                cam.move(-1);
            }
            */
            
            //lab 3 ex 8
            if(first==true)
            {
                cam.rotate(mouse.X * e.Time);
                first = false;
                lasttimex = mouse.X;
            }
            else
            {
                
                cam.rotate(mouse.X-lasttimex);
                lasttimex = mouse.X;
            }
            
            previousKeyboard = keyboard;

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            DrawAxes();

            DrawObjects();

            SwapBuffers();
        }

        private void DrawAxes()
        {

            GL.LineWidth(3.0f);

            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
            GL.End();

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();

        }

        private void DrawObjects()
        {
            //1.
            /*
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Vertex3(0, 1, 2);
            GL.Vertex3(2, 3, 2);
            GL.Vertex3(3, 1, 2);
            GL.Vertex3(5, 4, 2);

            GL.End();
            */
            //LAB 3.8
            t.Draw();

        }
        
    }
}
