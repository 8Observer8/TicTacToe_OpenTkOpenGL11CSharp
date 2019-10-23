
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

        // Called only once at the beginning
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Title = "Tic-Tac-Toe";
            Width = 192;
            Height = 192;
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

            // Set a triangle color
            GL.Color3(0f, 1f, 0f);

            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex2(-0.5f, -0.5f);
            GL.Vertex2(0.5f, -0.5f);
            GL.Vertex2(0f, 0.5f);
            GL.End();

            // Swaps the front and back buffer
            SwapBuffers();
        }
    }
}
