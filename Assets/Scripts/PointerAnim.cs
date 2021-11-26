using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        while (true)
        {
            for (int i = 0; i < 100; i++)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 3.6f*i, 90));
                yield return new WaitForSeconds(0.01f);
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
    }
}
