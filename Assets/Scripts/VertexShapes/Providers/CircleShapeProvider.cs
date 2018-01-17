using UnityEngine;

namespace Assets.Scripts.VertexShapes.Providers
{
    public class CircleShapeProvider : MonoBehaviour, IVertexShapeProvider
    {
        public int VertexCount;
        public float Radius;

        public VertexShape Provide()
        {
            return Primitives.Circle.GetVertices(VertexCount, Radius);
        }
    }
}
