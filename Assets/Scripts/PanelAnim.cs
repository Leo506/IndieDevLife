using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnim : MonoBehaviour
{
    Vector3 endScale;

    private void Start()
    {
        endScale = gameObject.transform.localScale;
    }

    public void StartAnim()
    {
        StopAnim();
        StartCoroutine(Animate());
        Debug.Log("Анмация началась");
    }

    public void StopAnim()
    {
        StopAllCoroutines();
        gameObject.transform.localScale = endScale;
    }

    IEnumerator Animate()
    {
        float scalePerIteration = endScale.x / 50;

        for (int i = 0; i < 50; i++)
        {
            gameObject.transform.localScale = new Vector3(scalePerIteration * i, scalePerIteration * i, 1);
            yield return new WaitForSeconds(0.005f);
        }
    }
}
