using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using System.IO;
using openTk.Graphics;

namespace openTk
{
    public sealed class GameContainer : OpenTK.GameWindow
    {
        private VertexBuffer<Vertex> VertexBuffer;
        private ShaderProgram Shaders;
        private VertexArray<Vertex> VertexArray;
        private Matrix4Uniform ProjectionMatrix;

        public GameContainer()
            : base(800, 600, GraphicsMode.Default, "test", OpenTK.GameWindowFlags.Default, DisplayDevice.Default, 4, 0, GraphicsContextFlags.ForwardCompatible)
        {
            Console.WriteLine("version: {0}", GL.GetString(StringName.Version));
        }
        
        protected override void OnLoad(EventArgs e)
        {
            GL.Enable(EnableCap.Texture2D);

            //set up the arrays
            VertexBuffer = new VertexBuffer<Vertex>(Vertex.Size);
            VertexBuffer.AddVertex(new Vertex(new Vector3(-1, -1, -2), Color4.Red));
            VertexBuffer.AddVertex(new Vertex(new Vector3(1, 1, -2), Color4.Blue));
            VertexBuffer.AddVertex(new Vertex(new Vector3(1, -1, -2), Color4.Green));

            //shader business
            var vertexShaderText = File.ReadAllText("./graphics/VertexShader.txt");
            var vertexShader = new Shader(ShaderType.VertexShader, vertexShaderText);
            var fragmentShaderText = File.ReadAllText("./graphics/FragmentShader.txt");
            var fragmentShader = new Shader(ShaderType.FragmentShader, fragmentShaderText);

            //build program
            Shaders = new ShaderProgram(vertexShader, fragmentShader);

            //set up vertex layout
            VertexArray = new VertexArray<Vertex>(VertexBuffer, Shaders,
                new VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, Vertex.Size, 0),
                new VertexAttribute("vColor", 4, VertexAttribPointerType.Float, Vertex.Size, 12));

            //set up projection matrix
            ProjectionMatrix = new Matrix4Uniform("projectionMatrix");
            ProjectionMatrix.Matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, 16f / 9f, .1f, 100f);

            PrototypingMethods.LoadTexture();

            base.OnLoad(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //clears buffer
            GL.ClearColor(Color4.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            this.VertexBuffer.vertices[0].Position.X += .01f;

            Shaders.Use();
            ProjectionMatrix.Set(Shaders);

            VertexBuffer.Bind();
            VertexArray.Bind();

            VertexBuffer.BufferData();
            VertexBuffer.Draw();

            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.UseProgram(0);

            //bring rendered frame to front
            this.SwapBuffers();
        }
    }
}
