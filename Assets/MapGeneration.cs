using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateMesh();
    }

    public void CreateMesh()
    {
        //first we initialize vectors 
        Vector3 bottomLeft = new Vector3(0, -3, 0);
        Vector3 bottomRight = new Vector3(6, -3, 0);
        Vector3 topLeft = new Vector3(0, -3, 6);
        Vector3 topRight = new Vector3(6, -3, 6);

        Vector3[] vertices = new Vector3[]
        {
            topLeft,
            topRight,
            bottomLeft,
            bottomRight
        };

        Vector2[] uvs = new Vector2[vertices.Length];
        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        };

        int[] triangles = new int[]
        {
            0, 1, 2, 2, 1, 3
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;

        Vector2 bottomLeftCorner = new Vector2(0, 0);

        GameObject dungeonFloor = new GameObject("Mesh" + bottomLeftCorner, typeof(MeshFilter), typeof(MeshRenderer));

        dungeonFloor.AddComponent<MeshCollider>();
        dungeonFloor.transform.position = Vector3.zero;
        dungeonFloor.transform.localScale = Vector3.one;
        dungeonFloor.GetComponent<MeshFilter>().mesh = mesh;
        //dungeonFloor.GetComponent<MeshRenderer>().material = material;
        dungeonFloor.transform.parent = transform;


        LayerMask mask = LayerMask.GetMask("ground");
        dungeonFloor.layer = 8;

        dungeonFloor.GetComponent<MeshCollider>().sharedMesh = dungeonFloor.GetComponent<MeshFilter>().mesh;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
