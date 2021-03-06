using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEditor;

public class BezierQuadratic : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public Transform handle;

    public float percent;
    public int curveResolution = 10;

    [Header("Tween Stuff")]
    [Tooltip("How long the tween should take in seconds.")]
    [Range(.1f, 10)] public float tweenLength = 3;
    public AnimationCurve tweenSpeed;

    private float tweenTimer = 0;
    private bool isTweening = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTweening)
        {
            tweenTimer += Time.deltaTime;
            float p = tweenTimer / tweenLength;

            percent = tweenSpeed.Evaluate(p);

            if (tweenTimer > tweenLength) isTweening = false;

        }

        transform.position = CalcPositionOnCurve(percent);
    }

    public void PlayTween()
    {
        tweenTimer = 0;
        isTweening = true;
    }

    private Vector3 CalcPositionOnCurve(float percent)
    {
        // pC = lerp between pA and handle

        Vector3 c = AnimMath.Lerp(pointA.position, handle.position, percent);
        Vector3 d = AnimMath.Lerp(handle.position, pointB.position, percent);

        Vector3 f = AnimMath.Lerp(c, d, percent);

        return f;
    }

    private void OnDrawGizmos()
    {
        Vector3 p1 = pointA.position;

        for(int i = 1; i< curveResolution; i++)
        {
            float p = i / (float)curveResolution;

            Vector3 p2 = CalcPositionOnCurve(p);

            Gizmos.DrawLine(p1, p2);

            p1 = p2;
        }

        Gizmos.DrawLine(p1, pointB.position);
    }
}


[CustomEditor(typeof(BezierQuadratic))]
public class BezierQuadraticEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Play Tween"))
        {
            (target as BezierQuadratic).PlayTween();
        }
    }
}
