using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Originally coded by Game Dev Guide
//https://www.youtube.com/watch?v=--LB7URk60A&ab_channel=GameDevGuide
public class UIGridRenderer : Graphic
{
    public Vector2Int GridSize = new Vector2Int(1, 1);
    public float Thickness = 10f;

    private float RT_Width;
    private float RT_Height;
    private float CellWidth;
    private float CellHeight;

    public float GetCellWidth(){ return CellWidth; }

    protected override void OnPopulateMesh(VertexHelper VH)
    {
        VH.Clear();

        RT_Width = rectTransform.rect.width;
        RT_Height = rectTransform.rect.height;

        CellWidth = RT_Width / (float)GridSize.x;
        CellHeight = RT_Height / (float)GridSize.y;

        int CellCount = 0;

        for(int y = 0; y < GridSize.y; y++)
        {
            for (int x = 0; x < GridSize.x; x++)
            {
                DrawCell(x, y, CellCount, VH);
                CellCount++;
            }
        }
    }

    private void DrawCell(int x, int y, int index, VertexHelper VH)
    {
        float xPos = CellWidth * x;
        float yPos = CellHeight * y;

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(xPos, yPos);
        VH.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + CellHeight);
        VH.AddVert(vertex);

        vertex.position = new Vector3(xPos + CellWidth, yPos + CellHeight);
        VH.AddVert(vertex);

        vertex.position = new Vector3(xPos + CellWidth, yPos);
        VH.AddVert(vertex);

        //VH.AddTriangle(0, 1, 2); VH.AddTriangle(2, 3, 0);

        float widthSqr = Thickness * Thickness;
        float distanceSqr = widthSqr / 2f;
        float distance = Mathf.Sqrt(distanceSqr);

        vertex.position = new Vector3(xPos + distance, yPos + distance);
        VH.AddVert(vertex);

        vertex.position = new Vector3(xPos + distance, yPos + (CellHeight - distance));
        VH.AddVert(vertex);

        vertex.position = new Vector3(xPos + (CellWidth - distance), yPos + (CellHeight - distance));
        VH.AddVert(vertex);

        vertex.position = new Vector3(xPos + (CellWidth - distance), yPos + distance);
        VH.AddVert(vertex);

        int offset = index * 8;

        //Edges
        //--Left
        VH.AddTriangle(offset + 0, offset + 1, offset + 5); VH.AddTriangle(offset + 5, offset + 4, offset + 0);

        //--Top
        VH.AddTriangle(offset + 1, offset + 2, offset + 6); VH.AddTriangle(offset + 6, offset + 5, offset + 1);

        //--Right
        VH.AddTriangle(offset + 2, offset + 3, offset + 7); VH.AddTriangle(offset + 7, offset + 6, offset + 2);

        //--Bottom
        VH.AddTriangle(offset + 3, offset + 0, offset + 4); VH.AddTriangle(offset + 4, offset + 7, offset + 3);
    }
}
