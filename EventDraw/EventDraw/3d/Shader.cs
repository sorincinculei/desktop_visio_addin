using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace EventDraw._3d
{
    public class Shader
    {
        private readonly Dictionary<string, int> _uniformLocations;

        public readonly int Handle;
        private readonly string _frag;

        public Shader(string vert, string frag)
        {
            _frag = frag;

            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vert);
            CompileShader(vertexShader);

            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, frag);
            CompileShader(fragmentShader);

            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);

            LinkProgram(Handle);

            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);

            int numberOfUniforms;
            GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out numberOfUniforms);

            _uniformLocations = new Dictionary<string, int>();
            for (var i = 0; i < numberOfUniforms; i++)
            {
                var size1 = 0;
                var size2 = ActiveUniformType.Float;

                var key = GL.GetActiveUniform(Handle, i, out size1, out size2);
                var location = GL.GetUniformLocation(Handle, key);
                _uniformLocations.Add(key, location);
            }
        }

        private static void CompileShader(int shader)
        {
            GL.CompileShader(shader);

            // Check Compile error
            int code;
            GL.GetShader(shader, ShaderParameter.CompileStatus, out code);
            if (code == (int)All.True) return;
            var infoLog = GL.GetShaderInfoLog(shader);
            throw new Exception($"Error occurred whilst compiling Shader({shader}).\n\n{infoLog}");
        }

        private static void LinkProgram(int program)
        {
            GL.LinkProgram(program);

            // Check Link error
            int code;
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out code);
            if (code != (int)All.True)
                throw new Exception($"Error occurred whilst linking Program({program})");
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public int GetAttribLocation(string attribName)
        {
            return GL.GetAttribLocation(Handle, attribName);
        }

        private static string LoadSource(string path)
        {
            var sr = new StreamReader(path, Encoding.UTF8);
            return sr.ReadToEnd();
        }

        public void SetInt(string name, int data)
        {
            GL.UseProgram(Handle);
            GL.Uniform1(_uniformLocations[name], data);
        }

        public void SetFloat(string name, float data)
        {
            GL.UseProgram(Handle);
            GL.Uniform1(_uniformLocations[name], data);
        }

        public void SetMatrix4(string name, Matrix4 data)
        {
            GL.UseProgram(Handle);
            GL.UniformMatrix4(_uniformLocations[name], true, ref data);
        }

        public void SetVector3(string name, Vector3 data)
        {
            GL.UseProgram(Handle);
            GL.Uniform3(_uniformLocations[name], data);
        }

        public void SetVector4(string name, Vector4 data)
        {
            GL.UseProgram(Handle);
            GL.Uniform4(_uniformLocations[name], data);
        }
    }
}
