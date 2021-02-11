using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath
{
    public static float Lerp(float min, float max, float p, bool allowEx = true)
    {
        if (!allowEx)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }
        return (max - min) * p + min;
    }
    public static Vector3 Lerp(Vector3 min, Vector3 max, float p, bool allowEx = true)
    {
        if (!allowEx)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }
        return (max - min) * p + min;
    }
    public static Quaternion Lerp(Quaternion min, Quaternion max, float p, bool allowExtra = true)
    {
        Quaternion rot = Quaternion.identity;
        rot.x = Lerp(min.x, max.x, p, allowExtra);
        rot.y = Lerp(min.y, max.y, p, allowExtra);
        rot.z = Lerp(min.z, max.z, p, allowExtra);
        rot.w = Lerp(min.w, max.w, p, allowExtra);

        return rot;
    }

    public static float Slide(float curr, float target, float percentLeftAfter1)
    {
        float p = 1 - Mathf.Pow(percentLeftAfter1, Time.deltaTime);
        return AnimMath.Lerp(curr, target, p);
    }
    public static Vector3 Slide(Vector3 curr, Vector3 target, float percentLeftAfter1)
    {
        float p = 1 - Mathf.Pow(percentLeftAfter1, Time.deltaTime);
        return AnimMath.Lerp(curr, target, p);
    }
    public static Quaternion Slide(Quaternion current, Quaternion target, float percentLeft = 0.5f)
    {
        float p = 1 - Mathf.Pow(percentLeft, Time.deltaTime);
        return AnimMath.Lerp(current, target, p);
    }


    public static Vector3 SpotOnCircleXZ(float radius, float currentAngle)
    {
        Vector3 offset = new Vector3();
        offset.x = Mathf.Sin(currentAngle) * radius;
        offset.z = Mathf.Cos(currentAngle) * radius;

        return offset;
    }
}
