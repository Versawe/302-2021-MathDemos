using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LerpBetweenPoints : MonoBehaviour
{

    public Transform pointA;

    public Transform pointB;
    public float percent;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = AnimMath.Lerp(pointA.position, pointB.position, percent);
    }
}
