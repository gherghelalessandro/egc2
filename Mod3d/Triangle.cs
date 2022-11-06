using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3d
{
    public class Triangle
    {
        Vector3[] v;
        Color color;
        int colorr,colorb,colorg;
        public bool red, blue, green;
        public Triangle(string path)
        {
            string[] parts = File.ReadAllLines(path);
            this.color = Color.FromArgb(0,0,0);
            v = new Vector3[3];
            red = false;
            blue = false;
            green = false;
            for (int i=0;i<3;i++)
            {
                string[] s = parts[i].Split(',');
                
                if(s.Length<=3)
                {
                    v[i] = new Vector3(float.Parse(s[0]),float.Parse(s[1]), float.Parse(s[2]));
                }
              
            }
        }
        public void Draw()
        {
            GL.Color3(color);
            GL.Begin(PrimitiveType.Triangles);
            
            for (int i=0;i<3;i++)
            {
                GL.Vertex3(v[i]);
            }
            GL.End();
        }
        //lab 3 ex 9
        public void brightenup()
        {
            if(red==true)
            {
                if (colorr + 5 <= 255)
                {
                    colorr += 5;
                }
            }
            else if(blue==true)
            {
                if (colorb + 5 <= 255)
                {
                    colorb += 5;
                }
            }
            else if(green==true)
            {
                if(colorg+5<=255)
                {
                    colorg += 5;
                }
            }
           
            color = Color.FromArgb(colorr, colorg, colorb);


        }
        public void brightendown()
        {
            if (red == true)
            {
                if (colorr - 5 >=0)
                {
                    colorr -= 5;
                }
            }
            else if (blue == true)
            {
                if (colorb - 5 >=0)
                {
                    colorb -=5;
                }
            }
            else if (green == true)
            {
                if (colorg - 5 >=0)
                {
                    colorg -= 5;
                }
            }
           
            color = Color.FromArgb(colorr, colorg, colorb);
        }
        //lab 3 ex 8
        public void changecolor()
        {
            Random r = new Random();
            colorr=r.Next(0,255);
            colorb = r.Next(0, 255);
            colorg = r.Next(0, 255);
            color=Color.FromArgb(colorr, colorg, colorb);
        }
    }
}
