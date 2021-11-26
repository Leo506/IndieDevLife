using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour
{
    [SerializeField] Image _createdByPanel;
    [SerializeField] Text _text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AppearText());
    }

    IEnumerator AppearText() {
        var textColor = _text.color;
        for (int i = 0; i <= 25; i++)
        {
            _text.color = new Color(textColor.r, textColor.g, textColor.b, i*0.04f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);

        StartCoroutine(AppearTitles());
    }

    IEnumerator AppearTitles() {
        for (int i = 0; i <= 25; i++)
        {
            _createdByPanel.color = new Color(1, 1, 1, i*0.04f);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
