using UnityEngine;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour
{
    public static Vector3 FindClosestpoint(Vector3 pos,List<Vector3> ways)
    {
        Vector3 result = new Vector3(0,0,0);
        float dist = float.PositiveInfinity;
        foreach (Vector3 ei in ways)
        {
            float d = (ei - pos).sqrMagnitude;
            if (d < dist)
            {
                result = ei;
                dist = d;
            }
        }
        return result;
    }

    public static Transform FindClosestway(Vector3 pos, List<Transform> ways)
    {
        Transform result = null;
        float dist = float.PositiveInfinity;
        foreach (Transform ei in ways)
        {
            float d = (ei.transform.position - pos).sqrMagnitude;
            if (d < dist)
            {
                result = ei;
                dist = d;
            }
        }
        return result;
    }

}
