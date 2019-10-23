
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TicTacToe
{
    class Window : GameWindow
    {
        private char[,] _gameField = new char[,]
        {
            { ' ', 'x', ' ' },
            { ' ', 'x', ' ' },
            { '0', ' ', ' ' }
        };

        private bool _canDraw = false;

        // Called only once at the beginning
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Title = "Tic-Tac-Toe";
            Width = 192;
            Height = 192;

            // Enable textures and transparentcy
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            Setup2DGraphics(Width, Height);

            int texture = Loader.LoadTexture("Assets/Textures/GameField.png");
            if (texture == -1)
            {
                return;
            }

            _canDraw = true;
        }

        // Called 60 time per second before OnRenderFrame()
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        // Called 60 time per second after OnUpdateFrame()
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            // Set a viewport
            GL.Viewport(0, 0, Width, Height);

            // Clears the render canvas
            GL.Clear(ClearBufferMask.ColorBufferBit);

            if (!_canDraw) return;

            // Set a triangle color
            //GL.Color3(0f, 1f, 0f);

            GL.Begin(PrimitiveType.Triangles);
            {
                // Left top triangle
                GL.TexCoord2(0f, 0f); GL.Vertex2(0f, 0f);
                GL.TexCoord2(0f, 0.33f); GL.Vertex2(0f, 64f);
                GL.TexCoord2(0.33f, 0f); GL.Vertex2(64f, 0f);
                // Right bottom triangle
                GL.TexCoord2(0f, 0.33f); GL.Vertex2(0f, 64f);
                GL.TexCoord2(0.33f, 0.33f); GL.Vertex2(64f, 64f);
                GL.TexCoord2(0.33f, 0f); GL.Vertex2(64f, 0f);
            }
            GL.End();

            // Swaps the front and back buffer
            SwapBuffers();
        }

        private void Setup2DGraphics(float width, float height)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0f, width, height, 0f, -100f, 100f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }
    }
}
