using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{

    public void StartSpin()
    {
        int priceIndex = Random.Range(0, 4);
        float spinAngle = 1080 + 90 * priceIndex;
        StartCoroutine(Spinning(spinAngle));
    }

    IEnumerator Spinning(float angle)
    {
        var anglePerPeriod = (angle / 3) / 100;


        for (int i = 1; i <= 300; i++)
        {
            var zRotation = anglePerPeriod * i;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));

            yield return new WaitForSeconds(0.01f);
        }
    }
}
