using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDraw._3d
{
    public static class Shaders
    {
        /// <summary>
        /// </summary>
        public const string LightingTempFrag =
            @"#version 330 core
            out vec4 FragColor;

            //In order to calculate some basic lighting we need a few things per model basis, and a few things per fragment basis:
            uniform vec3 objectColor; //The color of the object.
            uniform vec3 lightColor; //The color of the light.
            uniform vec3 lightPos; //The position of the light.

            in vec3 Normal; //The normal of the fragment is calculated in the vertex shader.
            in vec3 FragPos; //The fragment position.

            void main()
            {
                float ambientStrength = 0.25;
                vec3 ambient = ambientStrength * lightColor;
                vec3 norm = normalize(Normal);
                vec3 lightDir = normalize(lightPos - FragPos);
                float diff = max(dot(norm, lightDir), 0.0) * 0.75;
                vec3 diffuse = diff * lightColor;
                vec3 result = (ambient + diffuse) * objectColor;
                FragColor = vec4(result, 1.0);
            }";

        /// <summary>
        /// </summary>
        public const string LightingFrag =
            @"#version 330 core
            out vec4 FragColor;

            //In order to calculate some basic lighting we need a few things per model basis, and a few things per fragment basis:
            uniform vec3 objectColor; //The color of the object.
            uniform vec3 lightColor; //The color of the light.
            uniform vec3 lightPos; //The position of the light.
            uniform float opacity;

            in vec3 Normal; //The normal of the fragment is calculated in the vertex shader.
            in vec3 FragPos; //The fragment position.

            void main()
            {
                float ambientStrength = 0.25;
                vec3 ambient = ambientStrength * lightColor;
                vec3 norm = normalize(Normal);
                vec3 lightDir = normalize(lightPos - FragPos);
                float diff = max(dot(norm, lightDir), 0.0) * 0.75;
                vec3 diffuse = diff * lightColor;
                vec3 result = (ambient + diffuse) * objectColor;
                FragColor = vec4(objectColor, opacity);
            }";

        /// <summary>
        /// </summary>
        public const string ShaderFrag =
            @"#version 330 core
            out vec4 FragColor;
            uniform vec3 lightColor;

            void main()
            {
                FragColor = vec4(lightColor, 1.0); // set all 4 vector values to 1.0
            }";

        /// <summary>
        /// </summary>
        public const string ShaderVert =
            @"# version 330 core
            layout(location = 0) in vec3 aPos;
            layout(location = 1) in vec3 aNormal;

            uniform mat4 model;
            uniform mat4 view;
            uniform mat4 projection;

            out vec3 Normal;
            out vec3 FragPos;

            void main()
            {
                gl_Position = vec4(aPos, 1.0) * model * view * projection;
                FragPos = vec3(vec4(aPos, 1.0) * model);
                Normal = -(aNormal * mat3(transpose(inverse(model))));
            }";

        /// <summary>
        /// </summary>
        public const string Shader2DFrag =
              "#version 330\r\n\r\nout vec4 FragColor;\r\nuniform vec4 lightColor;\r\n\r\nvoid main()\r\n{\r\n    FragColor = lightColor; \r\n\r\n}";

        /// <summary>
        /// </summary>
        public const string Shader2DVert =
              "#version 330\r\n\r\nlayout (location = 0) in vec3 aPos;\r\n\r\nvoid main(void)\r\n{\r\n    gl_Position = vec4(aPos, 1.0);    \r\n}";

        /// <summary>
        /// </summary>
        public const string TextureTempFrag =
            @"#version 330 core
            //The material is a collection of some values that we talked about in the last tutorial,
            //some crucial elements to the phong model.
            struct Material
            {
                vec3 ambient;
                vec3 diffuse;
                vec3 specular;

                float shininess; //Shininess is the power the specular light is raised to
            };
            //The light contains all the values from the light source, how the ambient diffuse and specular values are from the light source.
            //This is technically what we were using in the last episode as we were only applying the phong model directly to the light.
            struct Light
            {
                vec3 position;

                vec3 ambient;
                vec3 diffuse;
                vec3 specular;
            };
            //We create the light and the material struct as uniforms.
            uniform Light light;
            uniform Material material;
            //We still need the view position.
            uniform vec3 viewPos;
            uniform float opacity;

            out vec4 FragColor;

            in vec3 Normal;
            in vec3 FragPos;

            void main()
            {
                //ambient
                vec3 ambient = light.ambient * material.ambient; //Remember to use the material here.

                //diffuse 
                vec3 norm = normalize(Normal);
                vec3 lightDir = normalize(light.position - FragPos);
                float diff = max(dot(norm, lightDir), 0.0);
                vec3 diffuse = light.diffuse * (diff * material.diffuse); //Remember to use the material here.

                //specular
                vec3 viewDir = normalize(viewPos - FragPos);
                vec3 reflectDir = reflect(-lightDir, norm);
                float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
                vec3 specular = light.specular * (spec * material.specular); //Remember to use the material here.

                //Now the result sum has changed a bit, since we now set the objects color in each element, we now dont have to
                //multiply the light with the object here, instead we do it for each element seperatly. This allows much better control
                //over how each element is applied to different objects.
                vec3 result = ambient + diffuse + specular;
                FragColor = vec4(result, opacity);
            }";

        /// <summary>
        /// </summary>
        public const string TextureFrag =
            @"#version 330 core
            //The material is a collection of some values that we talked about in the last tutorial,
            //some crucial elements to the phong model.
            struct Material
            {
                vec3 ambient;
                vec3 diffuse;
                vec3 specular;

                float shininess; //Shininess is the power the specular light is raised to
            };
            //The light contains all the values from the light source, how the ambient diffuse and specular values are from the light source.
            //This is technically what we were using in the last episode as we were only applying the phong model directly to the light.
            struct Light
            {
                vec3 position;

                vec3 ambient;
                vec3 diffuse;
                vec3 specular;
            };
            //We create the light and the material struct as uniforms.
            uniform Light light;
            uniform Material material;
            //We still need the view position.
            uniform vec3 viewPos;
            uniform float opacity;

            out vec4 FragColor;

            in vec3 Normal;
            in vec3 FragPos;

            void main()
            {
                //ambient
                vec3 ambient = vec3(1.0, 1.0, 1.5) * 0.1; //Remember to use the material here.

                //diffuse 
                vec3 norm = normalize(Normal);
                vec3 lightDir = normalize(light.position - FragPos);
                float diff = max(dot(norm, lightDir), 0.0);
                //vec3 diffuse = diff * material.diffuse; //Remember to use the material here.

                //specular
                //vec3 viewDir = normalize(viewPos - FragPos);
                //vec3 reflectDir = reflect(-lightDir, norm);
                //float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
                //vec3 specular = light.specular * (spec * material.specular); //Remember to use the material here.

                //Now the result sum has changed a bit, since we now set the objects color in each element, we now dont have to
                //multiply the light with the object here, instead we do it for each element seperatly. This allows much better control
                //over how each element is applied to different objects.
                
                vec3 result = material.diffuse;
                //vec3 result = (ambient + diff) * material.diffuse;
                FragColor = vec4(result, opacity);
            }";

        /// <summary>
        /// </summary>
        public const string TextureVert =
              "#version 330\r\n\r\nlayout (location = 0) in vec3 aPos;\r\nlayout (location = 1) in vec3 aNormal;\r\nlayout (location = 2) in vec2 aTexture;\r\n\r\nuniform mat4 model;\r\nuniform mat4 view;\r\nuniform mat4 projection;\r\n\r\nout vec3 Normal;\r\nout vec3 FragPos;\r\nout vec2 textureCords;\r\n\r\nvoid main()\r\n{\r\n    gl_Position = vec4(aPos, 1.0) * model * view * projection;\r\n    textureCords = aTexture;\r\n    FragPos = vec3(vec4(aPos, 1.0) * model);\r\n    Normal = -(aNormal * mat3(transpose(inverse(model))));\r\n}";

        /// <summary>
        /// </summary>
        public const string Texture2DFrag =
              "#version 330\r\n\r\nout vec4 outputColor;\r\n\r\nin vec2 texCoord;\r\nuniform vec4 lightColor;\r\n\r\nuniform sampler2D texture0;\r\n\r\nvoid main()\r\n{\r\n    outputColor = texture(texture0, texCoord) * lightColor;\r\n}";

        /// <summary>
        /// </summary>
        public const string Texture2DVert =
              "#version 330\r\n\r\nlayout(location = 0) in vec3 aPosition;\r\nlayout(location = 1) in vec2 aTexCoord;\r\n\r\nout vec2 texCoord;\r\n\r\nvoid main(void)\r\n{\r\n    texCoord = aTexCoord;\r\n\r\n    gl_Position = vec4(aPosition, 1.0);\r\n}";
    }
}
