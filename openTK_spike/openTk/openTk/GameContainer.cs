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
        public GameContainer()
            : base(800, 600, GraphicsMode.Default, "test", OpenTK.GameWindowFlags.Default, DisplayDevice.Default, 4, 0, GraphicsContextFlags.ForwardCompatible)
        {
            Console.WriteLine("version: {0}", GL.GetString(StringName.Version));
        }

        protected override void OnLoad(EventArgs e)
        {

            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Texture2D);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            LogErrors("setup");

            var vertexShaderHandle = GL.CreateShader(ShaderType.VertexShader);
            var vertexText = File.ReadAllText("./graphics/VertexShader.txt");
            GL.ShaderSource(vertexShaderHandle, vertexText);
            GL.CompileShader(vertexShaderHandle);
            LogErrors("shader a");

            var fragmentShaderHandle = GL.CreateShader(ShaderType.FragmentShader);
            var fragmentText = File.ReadAllText("./graphics/FragmentShader.txt");
            GL.ShaderSource(fragmentShaderHandle, fragmentText);
            GL.CompileShader(fragmentShaderHandle);
            LogErrors("shader b");

            var shaderProgram = GL.CreateProgram();
            GL.AttachShader(shaderProgram, fragmentShaderHandle);
            GL.AttachShader(shaderProgram, vertexShaderHandle);
            GL.LinkProgram(shaderProgram);
            GL.UseProgram(shaderProgram);
            LogErrors("program");
            //Console.WriteLine(GL.GetProgramInfoLog(shaderProgram));

            var vertexPositionAttribute = GL.GetAttribLocation(shaderProgram, "aVertexPosition");
            LogErrors("attributes a 1");
            GL.EnableVertexAttribArray(vertexPositionAttribute);
            //should probably save that attribute off somewhere
            LogErrors("attributes a 2");

            var vertexTextureAttribute = GL.GetAttribLocation(shaderProgram, "aTextureCoord");
            GL.EnableVertexAttribArray(vertexTextureAttribute);
            //save off this too somwehere
            LogErrors("attributes b");

            var uPMatrixUniform = GL.GetUniformLocation(shaderProgram, "uPMatrix");
            var uMVMatrixUniform = GL.GetUniformLocation(shaderProgram, "uMVMatrix");
            var samplerUniform = GL.GetUniformLocation(shaderProgram, "uSampler");

            Shader = new ProtoShaderSet()
            {
                ShaderHandle = shaderProgram,
                AttributeHandles = new Dictionary<string, int>()
                {
                    { "aVertexPosition", vertexPositionAttribute },
                    { "aTextureCoord", vertexTextureAttribute }
                },
                SamplerUniform = samplerUniform,
                UPMatrixUniform = uPMatrixUniform,
                UMVMatrixUniform = uMVMatrixUniform,
            };
            LogErrors("attributes c");

            var texture = PrototypingMethods.LoadTexture3("dev", "Dev.png", null);
            LogErrors("texture");


            //sprite time
            var sprite1Vertices = new float[]
            {
                0, 0, 1,
                20, 0, 1,
                20, 20, 1,
                0, 20, 1
            };

            var sprite1VertexBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, sprite1VertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * sprite1Vertices.Length, sprite1Vertices, BufferUsageHint.StaticDraw);

            var sprite1VertexTextureMap = new float[]
            {
                0, 1, 2,
                0, 2, 3
            };

            var sprite1VertexTextureMapBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, sprite1VertexTextureMapBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(float) * sprite1VertexTextureMap.Length, sprite1VertexTextureMap, BufferUsageHint.StaticDraw);

            Sprite = new ProtoSprite()
            {
                VertexBuffer = sprite1VertexBuffer,
                VertexTextureMap = sprite1VertexTextureMap,
                VertexTextureMapBuffer = sprite1VertexTextureMapBuffer,
                Vertices = sprite1Vertices,
                Texture = texture,
                VertexBufferItemSize = 3,
                VertexTextureMapBufferItemSize = 1,
            };


            LogErrors("?");





            ////set up the arrays
            //VertexBuffer = new VertexBuffer<Vertex>(Vertex.Size);
            //VertexBuffer.AddVertex(new Vertex(new Vector3(-1, -1, -2), Color4.Red));
            //VertexBuffer.AddVertex(new Vertex(new Vector3(1, 1, -2), Color4.Blue));
            //VertexBuffer.AddVertex(new Vertex(new Vector3(1, -1, -2), Color4.Green));
            //LogErrors("vertex");

            ////shader business
            //var vertexShaderText = File.ReadAllText("./graphics/VertexShader.txt");
            //var vertexShader = new Shader(ShaderType.VertexShader, vertexShaderText);
            //var fragmentShaderText = File.ReadAllText("./graphics/FragmentShader.txt");
            //var fragmentShader = new Shader(ShaderType.FragmentShader, fragmentShaderText);
            //LogErrors("shadersa");


            ////build program
            //Shaders = new ShaderProgram(vertexShader, fragmentShader);
            //LogErrors("shadersb");

            ////set up vertex layout
            //VertexArray = new VertexArray<Vertex>(VertexBuffer, Shaders,
            //    new VertexAttribute("aVertexPosition", 3, VertexAttribPointerType.Float, Vertex.Size, 0),
            //    new VertexAttribute("aTextureCoord", 2, VertexAttribPointerType.Float, Vertex.Size, 0));
            //LogErrors("vertex");

            ////set up projection matrix
            //ProjectionMatrix = new Matrix4Uniform("projectionMatrix");
            //ProjectionMatrix.Matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, 16f / 9f, .1f, 100f);
            //LogErrors("projection");


            ////load texture, prototyping now
            //Texture = PrototypingMethods.LoadTexture3("dev", "Dev.png", null);
            //LogErrors("texture");

            base.OnLoad(e);
        }

        private ProtoShaderSet Shader;
        private class ProtoShaderSet
        {
            public int ShaderHandle;
            public Dictionary<string, int> AttributeHandles;
            public int UMVMatrixUniform;
            public int UPMatrixUniform;
            public int SamplerUniform;
        }

        private ProtoSprite Sprite;
        private class ProtoSprite
        {
            public float[] Vertices;
            public int VertexBuffer;
            public int VertexTextureMapBuffer;
            public float[] VertexTextureMap;
            public ProtoTexture Texture;
            internal int VertexBufferItemSize;
            internal int VertexTextureMapBufferItemSize;
        }

        private void LogErrors(string id)
        {
            var errors = GL.GetError();
            if (errors != ErrorCode.NoError)
            {
                Console.WriteLine($"{id} {errors.ToString()}");
            }
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //clears buffer
            GL.ClearColor(Color4.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //setup scene
            var Perspective = Matrix4.Perspective(45, 800f/600f, 0.1f, 2000);
            var mvMatrix = Matrix4.Identity;
            var cameraTranslation = Matrix4.Translation(new Vector3(0, 0, -1000));
            var rotation = Matrix4.Rotate(new Vector3(0, 0, 1), 0);

            //draw sprite
            var spriteTranslation = Matrix4.Translation(new Vector3(0, 0, 5));
            //rotate locally
            //move locally

            //position
            GL.BindBuffer(BufferTarget.ArrayBuffer, Sprite.VertexBuffer);
            GL.VertexAttribPointer(Shader.AttributeHandles["aVertexPosition"], Sprite.VertexBufferItemSize, VertexAttribPointerType.Float, false, 0, 0);

            //texture
            GL.BindBuffer(BufferTarget.ArrayBuffer, Sprite.Texture.TextureReference);
            GL.VertexAttribPointer(Shader.AttributeHandles["aTextureCoord"], Sprite.Texture.TextureBufferItemSize, VertexAttribPointerType.Float, false, 0, 0);

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, Sprite.Texture.TextureReference);
            GL.Uniform1(Shader.SamplerUniform, 0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Sprite.VertexTextureMapBuffer);

            var refMatrix = mvMatrix * cameraTranslation;// * rotation * spriteTranslation;
            GL.UniformMatrix4(Shader.UPMatrixUniform, false, ref Perspective);
            GL.UniformMatrix4(Shader.UMVMatrixUniform, false, ref refMatrix);

            GL.DrawElements(BeginMode.Triangles, Sprite.VertexTextureMap.Length, DrawElementsType.UnsignedShort, 0);




            LogErrors("?");












            //this.VertexBuffer.vertices[0].Position.X += .01f;

            //Shaders.Use();
            //ProjectionMatrix.Set(Shaders);

            //VertexBuffer.Bind();
            //VertexArray.Bind();

            //VertexBuffer.BufferData();
            //VertexBuffer.Draw();

            //GL.BindVertexArray(0);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.UseProgram(0);

            //bring rendered frame to front
            this.SwapBuffers();
        }
    }
}
