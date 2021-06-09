using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Originally coded by Game Dev Guide, edited for my program
//https://www.youtube.com/watch?v=--LB7URk60A&ab_channel=GameDevGuide

[ExecuteAlways]
public class UILineRenderer : Graphic
{
    public Vector2Int GridSize;
    public UIGridRenderer UIGR;
    public List<Vector2> Points;

    public float Thickness = 10f;

    private float RT_Width;
    private float RT_Height;
    private float UnitWidth;
    private float UnitHeight;

    private VertexHelper VH;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        VH = vh;

        UpdateGraph();
    }

    public void UpdateGraph()
    {
        VH.Clear();

        RT_Width = rectTransform.rect.width;
        RT_Height = rectTransform.rect.height;

        UnitWidth = RT_Width / (float)GridSize.x;
        UnitHeight = RT_Height / (float)GridSize.y;

        if (Points.Count < 2)
        {
            return;
        }

        float angle = 0;

        for (int i = 0; i < Points.Count; i++)
        {
            Vector2 point = Points[i];

            if (i < Points.Count - 1)
            {
                angle = GetAngle(Points[i], Points[i + 1]) + 45f;
            }

            DrawVerticesForPoint(point, angle);
        }

        for (int i = 0; i < Points.Count - 1; i++)
        {
            int index = i * 2;
            VH.AddTriangle(index + 0, index + 1, index + 3); VH.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

    public float GetAngle(Vector2 me, Vector2 target)
    {
        return (float)(Mathf.Atan2(target.y - me.y, target.x - me.x) * (180 / Mathf.PI));
    }

    private void DrawVerticesForPoint(Vector2 point, float angle)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-Thickness / 2, 0);
        vertex.position += new Vector3(UnitWidth * point.x, UnitHeight * point.y);
        VH.AddVert(vertex);

        vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(Thickness / 2, 0);
        vertex.position += new Vector3(UnitWidth * point.x, UnitHeight * point.y);
        VH.AddVert(vertex);
    }

    private void Update()
    {
        if(UIGR != null)
        {
            if(GridSize != UIGR.GridSize)
            {
                GridSize = UIGR.GridSize;
                SetVerticesDirty();
            }
        }
    }
}
