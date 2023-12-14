using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldGrid 
{
public static Vector3 GridPositionFromWorldPoint3D(Vector3 worldPos, float gridScale)
{
    float x = Mathf.Round(f:worldPos.x / gridScale) * gridScale;
    float y = Mathf.Round(f:worldPos.y / gridScale) * gridScale;
    float z = Mathf.Round(f:worldPos.z / gridScale) * gridScale;

    return new Vector3(x, y, z);

}
}
