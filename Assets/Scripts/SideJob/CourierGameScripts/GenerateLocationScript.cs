using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerateLocationScript
{
    public static Vector3[] GenerateDeliveryTargetsPosition() {
        Vector3[] targetsPos = new Vector3[3];
        
        Vector3 vec1 = new Vector3(Random.Range(-0.3f, -0.1f), 0.4f, Random.Range(0.1f, 0.3f));
        Vector3 vec2 = new Vector3(Random.Range(0.1f, 0.3f), 0.4f, (Random.Range(0.1f, 0.3f)));
        Vector3 vec3 = new Vector3(Random.Range(-0.3f, -0.1f), 0.4f, Random.Range(-0.3f, -0.1f));

        targetsPos[0] = vec1;
        targetsPos[1] = vec2;
        targetsPos[2] = vec3;

        return targetsPos;
    }
}
