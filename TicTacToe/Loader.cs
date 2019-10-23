
using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

namespace TicTacToe
{
    class Loader
    {
        public static int LoadTexture(string fileName)
        {
            // Create an image object
            Bitmap image = null;
            try
            {
                image = new Bitmap(fileName);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load the image: " + fileName);
                return -1;
            }

            // Enable unit0
            GL.ActiveTexture(TextureUnit.Texture0);

            // Create a texture object
            int texture = GL.GenTexture();

            // Bind the texture object to the target
            GL.BindTexture(TextureTarget.Texture2D, texture);

            // Set the texture parameters
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)All.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)All.ClampToEdge);

            BitmapData data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            // Set the texture image
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, image.Width, image.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            image.UnlockBits(data);

            return texture;
        }
    }
}
