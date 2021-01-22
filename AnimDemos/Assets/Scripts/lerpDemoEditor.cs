using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LerpDemo))]
public class lerpDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();  // draws normal editor part

        LerpDemo lerper = (LerpDemo) target;

        if (GUILayout.Button("Play"))
        {
            lerper.PlayTweenAnim();
        }
    }
}
