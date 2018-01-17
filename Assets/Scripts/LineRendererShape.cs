using Assets.Scripts.VertexShapes;
using UnityEngine;

namespace Assets.Scripts
{
    public class LineRendererShape : MonoBehaviour
    {
        private VertexShape _vertexShape;
        private LineRenderer _lineRenderer;

        public void Start()
        {
            // Get the shape to draw
            _vertexShape = GetComponent<IVertexShapeProvider>().Provide();

            // Get the line renderer we'll use to draw the shape
            _lineRenderer = GetComponent<LineRenderer>();

            // Setup line renderer
            _lineRenderer.positionCount = _vertexShape.Positions.Length;

            for (int i = 0; i < _vertexShape.Positions.Length; i++)
            {
                _lineRenderer.SetPosition(i, _vertexShape.Positions[i]);
            }
        }
    }
}
