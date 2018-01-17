using UnityEngine;

namespace Assets.Scripts.VertexShapes.Providers
{
    public class SphereVertexShapeProvider : MonoBehaviour, IVertexShapeProvider
    {
        public int SliceCount;
        public int StackCount;
        public float Radius;

        public VertexShape Provide()
        {
            return Primitives.Sphere.GetVertices(SliceCount, StackCount, Radius);
        }
    }
}
