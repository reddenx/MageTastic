using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using System.Drawing;

namespace openTk.Graphics
{
    public static class PrototypingMethods
    {
        public static void LoadTexture2()
        {
            GL.ClearColor(Color.CornflowerBlue);

            var textureSource = new Bitmap("Dev.png");
            var texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textureSource.Width, textureSource.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
            var lockedBits = textureSource.LockBits(new Rectangle(0, 0, textureSource.Width, textureSource.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, textureSource.Width, textureSource.Height, PixelFormat.Bgra, PixelType.UnsignedByte, lockedBits.Scan0);

            textureSource.UnlockBits(lockedBits);

            GL.BindTexture(TextureTarget.Texture2D, 0);
        }

        public static ProtoTexture LoadTexture3(string name, string path, Rectangle[] sourceRectangles)
        {
            var textureSource = new Bitmap(path);
            var texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textureSource.Width, textureSource.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
            var lockedBits = textureSource.LockBits(new Rectangle(0, 0, textureSource.Width, textureSource.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, textureSource.Width, textureSource.Height, PixelFormat.Bgra, PixelType.UnsignedByte, lockedBits.Scan0);
            textureSource.UnlockBits(lockedBits);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Nearest);

            GL.BindTexture(TextureTarget.Texture2D, 0);

            var rawWidth = textureSource.Width;
            var rawHeight = textureSource.Height;
            textureSource.Dispose();

            var textureCoordinateBuffers = new List<int>();
            if (sourceRectangles == null || sourceRectangles.Length == 0)
            {
                sourceRectangles = new[] { new Rectangle(0, 0, rawWidth, rawHeight) };
            }


            foreach (var rect in sourceRectangles)
            {
                var left = (float)rect.X / (float)rawWidth;
                var right = ((float)rect.X + (float)rect.Width) / (float)rawWidth;
                var top = 1 - ((float)rect.Y + (float)rect.Height) / (float)rawHeight;
                var bottom = 1 - (float)rect.Y / (float)rawHeight;

                var vertexMap = new float[]
                {
                    left, top,
                    right, top,
                    right, bottom,
                    left, bottom
                };

                var buffer = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, buffer);
                GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertexMap.Length, vertexMap, BufferUsageHint.StaticDraw);
                textureCoordinateBuffers.Add(buffer);
            }


            return new ProtoTexture()
            {
                Name = name,
                TextureReference = texture,
                sourceRectangles = sourceRectangles,
                TextureMapping = textureCoordinateBuffers,
                TextureBufferItemSize = 2,
            };
        }


        public static void LoadTexture()
        {
            //webgl workflow:
            //create a texture
            //bind it
            //setup parameters
            //unbind texture

            //setting up texture vertices for mapping
            //build up texture vertices, expand to use source rectangles later
            //build up texture coordinate buffers
            //for each texture vertex group (source rectangle)
            // - create a buffer
            // - bind that buffer as an array
            // - set buffer data sizes
            // - set aside buffer and reset current bindings






            var textureId = -1;
            GL.GenTextures(1, out textureId);
            GL.BindTexture(TextureTarget.Texture2D, textureId);

            var rawTexture = new System.Drawing.Bitmap("Dev.png");
            var data = rawTexture.LockBits(new System.Drawing.Rectangle(0, 0, rawTexture.Width, rawTexture.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            rawTexture.UnlockBits(data);
        }

    }

    public class ProtoRenderableSurface
    {
        public Vector2 Origin;
        public VertexBuffer<Vertex> VertexBuffer;
        public ProtoTextureMapBuffer TextureMapBuffer;
        public ProtoTexture Texture;
    }

    public class ProtoTexture
    {
        public string Name;
        public List<int> TextureMapping;
        public int TextureReference;
        public int TextureBufferItemSize;
        public Rectangle[] sourceRectangles;
    }

    public class ProtoTextureMapBuffer
    { }
}
