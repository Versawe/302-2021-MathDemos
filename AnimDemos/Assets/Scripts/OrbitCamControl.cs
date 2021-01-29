using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamControl : MonoBehaviour
{

    float pitch = 0;
    float targetPitch = 0;

    float pitch2 = 0;
    float targetPitch2 = 0;

    float dis = 10;
    float targetDis = 10;

    public float mouseSensitivityX = 6;
    public float mouseSensitivityY = -6;
    public float scrollSense = 10;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            float mouseY = Input.GetAxis("Mouse Y");
            targetPitch += mouseY * mouseSensitivityY;

            float mouseX = Input.GetAxis("Mouse X");
            targetPitch2 += mouseX * mouseSensitivityX;
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        targetDis += scroll * scrollSense;

        cam.transform.localPosition = new Vector3(0,0, -dis);

        dis = AnimMath.Slide(dis,targetDis, .05f); //ease

        targetDis = Mathf.Clamp(targetDis, 2.5f, 15f);
        targetPitch = Mathf.Clamp(targetPitch, -89, 89);

        pitch = AnimMath.Slide(pitch, targetPitch, .05f); //ease
        pitch2 = AnimMath.Slide(pitch2, targetPitch2, .05f);//eASE

        transform.rotation = Quaternion.Euler(pitch, pitch2, 0);
    }
}
