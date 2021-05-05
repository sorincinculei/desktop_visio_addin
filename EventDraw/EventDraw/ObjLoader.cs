using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using OpenTK;

namespace EventDraw
{
    public static class ObjLoader
    {
        public static float[] Load(string path)
        {
            var lines = File.ReadAllLines(path);
            var vertices = new List<float[]>();
            var final = new List<float>();
            foreach (var line in lines)
            {
                var lineSlitted = line.Split(' ');
                if (lineSlitted[0] == "v")
                {
                    var toAdd = new float[3];
                    toAdd[0] = float.Parse(lineSlitted[1]);
                    toAdd[1] = float.Parse(lineSlitted[2]);
                    toAdd[2] = float.Parse(lineSlitted[3]);
                    vertices.Add(toAdd);
                }

                if (lineSlitted[0] == "f")
                {
                    var t1 = lineSlitted[1].Split('/');
                    var t2 = lineSlitted[2].Split('/');
                    var t3 = lineSlitted[3].Split('/');


                    var v1 = vertices[int.Parse(t1[0]) - 1];
                    var v2 = vertices[int.Parse(t2[0]) - 1];
                    var v3 = vertices[int.Parse(t3[0]) - 1];

                    var v01 = new Vector3(v1[0], v1[1], v1[2]);
                    var v02 = new Vector3(v2[0], v2[1], v2[2]);
                    var v03 = new Vector3(v3[0], v3[1], v3[2]);

                    var l1 = v02 - v01;
                    var l2 = v03 - v01;

                    var n = Vector3.Cross(l2, l1);

                    final.Add(v1[0]);
                    final.Add(v1[1]);
                    final.Add(v1[2]);
                    final.Add(n.X);
                    final.Add(n.Y);
                    final.Add(n.Z);
                    final.Add(v2[0]);
                    final.Add(v2[1]);
                    final.Add(v2[2]);
                    final.Add(n.X);
                    final.Add(n.Y);
                    final.Add(n.Z);
                    final.Add(v3[0]);
                    final.Add(v3[1]);
                    final.Add(v3[2]);
                    final.Add(n.X);
                    final.Add(n.Y);
                    final.Add(n.Z);
                }
            }


            return final.ToArray();
        }
    }
}
