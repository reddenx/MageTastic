using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;

namespace openTk.Graphics
{
    sealed class Shader
    {
        private readonly int handle;

        public int Handle { get { return this.handle; } }

        public Shader(ShaderType type, string code)
        {
            // create shader object
            this.handle = GL.CreateShader(type);

            // set source and compile shader
            GL.ShaderSource(this.handle, code);
            GL.CompileShader(this.handle);
        }
    }
}
