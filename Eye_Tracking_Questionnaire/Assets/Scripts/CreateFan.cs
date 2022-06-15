using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class CreateFan : MonoBehaviour
{
    public float radius = 10.0f;
    public float holeRadius = 5.0f;
    public float startDegree = 10.0f;
    public float endDegree = 170.0f;
    public int split = 5;
    public Color color    = new Color(1, 0, 0, 0); //RGBA
  
    void Start()
    {
        MeshFilter m = this.GetComponent<MeshFilter>();
        m.mesh = createMesh();
    }
    void Update()
    {
    }
    Mesh createMesh()
    {
        if(Mathf.Approximately(holeRadius , 0.0f)){
            return createSector();
        }
        return createDonuts();
    }
    Mesh createSector()
    {
        Mesh mesh = new Mesh();
        //頂点座標計算
        Vector3[] vertices = new Vector3[2 + split];
        Vector2[] uv = new Vector2[2 + split];
        vertices[0] = new Vector3(0f, 0f, 0f);
        uv[0] = new Vector2(0.5f, 0.5f);
        float deltaRad = Mathf.Deg2Rad * ((endDegree - startDegree) / (float)split);
        for (int i = 1; i < 2 + split; i++)
        {
            float x = Mathf.Cos(deltaRad * (i - 1) + (Mathf.Deg2Rad * startDegree));
            float y = Mathf.Sin(deltaRad * (i - 1) + (Mathf.Deg2Rad * startDegree));
            vertices[i] = new Vector3(
                x * radius,
                y * radius,
                0.0f);
            uv[i] = new Vector2(x * 0.5f + 0.5f, y * 0.5f + 0.5f);
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        //三角形を構成する頂点のindexを，順に設定していく
        int[] triangles = new int[3 * split];
        for (int i = 0; i < split; i++)
        {
            triangles[(i * 3)] = 0;
            triangles[(i * 3) + 1] = i + 1;
            triangles[(i * 3) + 2] = i + 2;
        }
        mesh.triangles = triangles;
        return mesh;
    }
    Mesh createDonuts()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[2 + 2 * split];
        Vector2[] uv = new Vector2[2 + 2 * split];
        //頂点座標計算
        float deltaRad = Mathf.Deg2Rad * ((endDegree - startDegree) / (float)split);
        int indexOffset = vertices.Length / 2;
        for (int i = 0; i <vertices.Length/2; i++)
        {
            float x = Mathf.Cos(deltaRad * (i - 1) + (Mathf.Deg2Rad * startDegree));
            float y = Mathf.Sin(deltaRad * (i - 1) + (Mathf.Deg2Rad * startDegree));
            //外側
            vertices[i] = new Vector3(
                x * radius,
                y * radius,
                0.0f);
            //内側
            vertices[i + indexOffset] = new Vector3(
                x * holeRadius,
                y * holeRadius,
                0.0f);
            uv[i] = new Vector2(x * 0.5f + 0.5f, y * 0.5f + 0.5f);
            uv[i + indexOffset] = new Vector2(x * 0.5f * (holeRadius / radius) + 0.5f, y * 0.5f * (holeRadius / radius) + 0.5f);
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        //三角形を構成する頂点のindexを，順に設定していく
        int[] triangles = new int[6 * split];
        for (int i = 0; i < split; i++)
        {
            triangles[(i * 6) + 0] = i;
            triangles[(i * 6) + 1] = i + 1;
            triangles[(i * 6) + 2] = (i + indexOffset) + 1;
            triangles[(i * 6) + 3] = i;
            triangles[(i * 6) + 4] = (i + indexOffset) + 1;
            triangles[(i * 6) + 5] = (i + indexOffset);
        }
        mesh.triangles = triangles;
        
        StandardShaderUtils.ChangeRenderMode(GetComponent<MeshRenderer>().material, StandardShaderUtils.BlendMode.Fade);
        
        GetComponent<MeshRenderer>().material.color = color;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        return mesh;
    }
}