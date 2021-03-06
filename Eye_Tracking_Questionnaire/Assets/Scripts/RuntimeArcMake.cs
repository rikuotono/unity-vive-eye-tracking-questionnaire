using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics.Eventing.Reader;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
// [RequireComponent(typeof(MeshCollider))]

public class RuntimeArcMake : MonoBehaviour
{
    public int areaAngle  = 90; //作成する角度
    int startAngle = 0;  //スタート地点の角度
    int quality = 100;   //360degのときのtriangle数
    [SerializeField] Color color    = new Color(1, 0, 0, 0); //RGBA
    [SerializeField] Vector3 scale  = new Vector3(10,1,10);  //大きさ
 
    private Vector3[] vertices; //頂点
    private int[] triangles;    //index

    public bool _ringRunOn = false;

    // private GameObject _UIController;
    // Start is called before the first frame update
    void Start()
    {
        makeParams();
        // _UIController = GameObject.Find("UIController");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        makeParams();
        setParams();
    }
    
    private void makeParams(){
        List<Vector3> vertList = new List<Vector3>();
        List<int> triList = new List<int>();
 
        vertList.Add(new Vector3(0,0,0));  //原点
 
        float th,v1,v2;

        if (_ringRunOn == true)
        {
            areaAngle += 2;
            int max = (int) quality * areaAngle / 360;

            if (max != 0)
            {
                for (int i = 0; i <= max; i++)
                {
                    th = i * areaAngle / max + startAngle;
                    v1 = Mathf.Sin(th * Mathf.Deg2Rad);
                    v2 = Mathf.Cos(th * Mathf.Deg2Rad);
                    vertList.Add(new Vector3(v1, 0, v2));
                    if (i <= max - 1)
                    {
                        triList.Add(0);
                        triList.Add(i + 1);
                        triList.Add(i + 2);
                    }
                }    
            }
        }

        else
        {
            areaAngle = 0;
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
        // GetComponent<MeshCollider>().sharedMesh = mesh;

        // 色指定
        GetComponent<MeshRenderer>().material.color = color;
    }
}
