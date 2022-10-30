﻿using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace test1opentk
{
    public struct Texture2D
    {
        private int id;
        private int width, height;

        public int ID
        {
            get { return id; }
        }
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public Texture2D(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }
    }
}