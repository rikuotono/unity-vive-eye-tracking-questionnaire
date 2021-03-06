using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MakeCircle : MonoBehaviour {
    public int areaAngle  = 90; //作成する角度
    public int startAngle = 0;  //スタート地点の角度
    public int quality = 100;   //360degのときのtriangle数
    public Color color    = new Color(1, 0, 0, 0); //RGBA
    public Vector3 scale  = new Vector3(10,1,10);  //大きさ
 
    private Vector3[] vertices; //頂点
    private int[] triangles;    //index
 
    private void makeParams(){
        List<Vector3> vertList = new List<Vector3>();
        List<int> triList = new List<int>();
 
        vertList.Add(new Vector3(0,0,0));  //原点
 
        float th,v1,v2;
        int max=(int)quality*areaAngle/360;
        for (int i=0;i<=max;i++){
            th=i*areaAngle/max + startAngle;
            v1=Mathf.Sin(th * Mathf.Deg2Rad);
            v2=Mathf.Cos(th * Mathf.Deg2Rad);
            vertList.Add(new Vector3(v1,0,v2));
            if(i<=max-1){
                triList.Add(0);triList.Add(i+1);triList.Add(i+2);
            }
        }
        vertices  = vertList.ToArray();
        triangles = triList.ToArray();
    }
 
    private void setParams(){
        Mesh mesh = new Mesh();
 
        mesh.vertices = vertices;
        mesh.triangles = triangles;
 
        // 法線とバウンディングの計算
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
 
        mesh.name = "arcMesh";
        transform.localScale = scale;
 
        GetComponent<MeshFilter>().sharedMesh = mesh;

        StandardShaderUtils.ChangeRenderMode(GetComponent<MeshRenderer>().material, StandardShaderUtils.BlendMode.Opaque);
        
        // 色指定
        GetComponent<MeshRenderer>().material.color = color;
    }
 
    void Start(){
        makeParams();
        setParams();
    }
}