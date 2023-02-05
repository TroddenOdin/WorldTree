using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    public GameObject fogOfWarPlane;
    private Transform fogPlayer;
    public LayerMask fogLayer;
    public float radius = 5f;
    private float radiusSqr { get { return radius * radius; } }

    private Mesh fogMesh;
    private Vector3[] fogVertices;
    private Color[] fogColors;
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        //fogPlayer = GameObject.FindGameObjectWithTag("Unit").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, fogPlayer.position - transform.position);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 1000, fogLayer, QueryTriggerInteraction.Collide))
        {
            for (int i=0; i < fogVertices.Length; i++)
            {
                Vector3 v = fogOfWarPlane.transform.TransformPoint(fogVertices[i]);
                float dist = Vector3.SqrMagnitude(v - hit.point);
                if (dist < radiusSqr)
                {
                    float alpha = Mathf.Min(fogColors[i].a, dist / radiusSqr);
                    fogColors[i].a = alpha;
                }
            }
            UpdateColor();
        }
    }

    void Initialize()
    {
        fogMesh = fogOfWarPlane.GetComponent<MeshFilter>().mesh;
        fogVertices = fogMesh.vertices;
        fogColors = new Color[fogVertices.Length];
        for (int i=0; i < fogColors.Length; i++)
        {
            fogColors[i] = Color.gray;
        }
        
    }

    void UpdateColor()
    {
        fogMesh.colors = fogColors;
    }
}
