using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTowards : MonoBehaviour
{
    public Transform target;

    private Camera cam;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }
    void Update()
    {
        //slides postion
        transform.position = AnimMath.Slide(transform.position, target.position, .01f);

        //get vec to target
        Vector3 vectorToTarget = target.position - cam.transform.position;

        //create desired rotation
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        //set camera to ease
        cam.transform.rotation = AnimMath.Slide(cam.transform.rotation, targetRotation, .05f);

    }
}
