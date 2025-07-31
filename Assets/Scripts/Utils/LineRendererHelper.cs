using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererHelper : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public List<Transform> positions;

    private void Start()
    {
        lineRenderer.positionCount = positions.Count;
    }

    void Update()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i].position);
        }
    }
}
