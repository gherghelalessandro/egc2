using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3d
{
    public class Camera
    {
        Vector3 position;
        Vector3 eye;
        Matrix4 lookat;
        public Camera(Vector3 v,Vector3 e)
        {
            position = v;
            eye = e;
        }
        public void setmatrix()
        {
            lookat = Matrix4.LookAt(position, eye, new Vector3(0, 1, 0));
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }
       
        public void move(int i)
        {
            position.Z -= i;
            eye.Z -= i;
        }
        //lab3.8
        public void rotate(double i)
        {
            GL.Rotate(i, 0, 10, 0);
        }
        
    }
}
