using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI tm;

    public LerpDemo lerper;

    public Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float p = lerper.getCurrentPercent;
        slide.SetValueWithoutNotify(p);

    }

    public void SliderTimeUpdated(float amt)
    {
        Time.timeScale = amt;
        tm.text = Time.timeScale.ToString();
    }

    public void SliderLerpUpdated(float amt)
    {
        lerper.DoTheLerp(amt);
        
    }
}
