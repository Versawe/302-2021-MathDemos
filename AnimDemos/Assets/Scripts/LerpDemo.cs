using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    public Transform posA;
    public Transform posB;

    [Range(-1, 2)] public float percent = 0;

    public float animationLength = 2;
    private float animationPlayheadTime = 0;
    private bool isAnimPlaying = false;

    public AnimationCurve animationCurve;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAnimPlaying)
        {
            //move playhead forward
            animationPlayheadTime += Time.deltaTime;
            //calc new value for percent
            percent = animationPlayheadTime / animationLength;
            //clamp percent value
            percent = Mathf.Clamp(percent, 0, 1);

            float p = animationCurve.Evaluate(percent);
            //percent = percent * percent; //ease-in: speeding up
            //percent = percent * percent * (3-2 * percent); // easeInOut

            //move object to lerpad position
            DoTheLerp(p);
            if (percent >= 1) isAnimPlaying = false;
        }
        
    }

    private void DoTheLerp(float p)
    {
        transform.position = AnimMath.Lerp(posA.position, posB.position, p);
    }

    private void OnValidate()
    {
        DoTheLerp(percent);
    }

    public void PlayTweenAnim()
    {
        isAnimPlaying = true;
        animationPlayheadTime = 0;
    }
}
