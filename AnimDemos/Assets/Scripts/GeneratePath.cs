using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class GeneratePath : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 20)] public float radius = 5;

    LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void GeneratePoints()
    {
        lr = GetComponent<LineRenderer>();

        //generate points
        float rad = 0;

        Vector3[] pts = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius + transform.position;
            rad += Mathf.PI * 2 / num; // increases the angle
        }
        lr.positionCount = num;
        lr.SetPositions(pts);
    }

    void OnValidate()
    {
        GeneratePoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
