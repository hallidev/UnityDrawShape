using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.VertexShapes.Providers
{
    public static class Primitives
    {
        public static List<VertexInfo> ConvertToVertexInfo(VertexShape shape)
        {
            var infoList = new List<VertexInfo>();

            for (int i = 0; i < shape.Positions.Length; i++)
            {
                infoList.Add(new VertexInfo
                {
                    Position = shape.Positions[i],
                    Normal = shape.Normals[i]
                });
            }

            return infoList;
        }

        public static class Sphere
        {
            public static VertexShape GetVertices(int stacks, int slices, float radius)
            {
                var positions = new Vector3[stacks * slices];
                var normals = new Vector3[stacks * slices];

                int elementIndex = 0;
                // Calc The Vertices
                for (int i = 0; i < stacks; i++)
                {
                    float V = i / (float)stacks;
                    float phi = V * Mathf.PI;

                    // Loop Through Slices
                    for (int j = 0; j < slices; j++)
                    {

                        float U = j / (float)slices;
                        float theta = U * (Mathf.PI * 2);

                        // Calc The Vertex Positions
                        float x = Mathf.Cos(theta) * Mathf.Sin(phi);
                        float y = Mathf.Cos(phi);
                        float z = Mathf.Sin(theta) * Mathf.Sin(phi);

                        Vector3 position = new Vector3(x, y, z) * radius;

                        // Push Back Vertex Data
                        positions[elementIndex] = position;
                        normals[elementIndex] = position.normalized;

                        elementIndex++;
                    }
                }

                return new VertexShape
                {
                    Positions = positions,
                    Normals = normals
                };
            }
        }

        public static class Circle
        {
            public static VertexShape GetVertices(int elementCount, float radius)
            {
                var positions = new Vector3[elementCount];
                var normals = new Vector3[elementCount];

                for (int i = 0; i < elementCount; i++)
                {
                    float angle = Mathf.Deg2Rad * (i / (float)elementCount) * 360.0f;
                    var position = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0.0f);

                    // Gets a vector that points from the zero to the position
                    var heading = position - Vector3.zero;
                    var distance = heading.magnitude;
                    var normal = heading / distance; // This is now the normalized direction.

                    positions[i] = position;
                    normals[i] = normal;
                }

                return new VertexShape
                {
                    Positions = positions,
                    Normals = normals
                };
            }
        }
    }
}
