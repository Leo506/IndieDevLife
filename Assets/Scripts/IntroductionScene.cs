using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroductionScene : MonoBehaviour
{
    [SerializeField] Image _text;
    [SerializeField] Image _playButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Appear());
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator Appear()
    {
        var textColor = _text.color;

        for (int i = 0; i < 100; i++)
        {
            _text.color = new Color(textColor.r, textColor.g, textColor.b, (float)i / 100);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 100; i++)
        {
            _playButton.color = new Color(1, 1, 1, (float)i / 100);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
