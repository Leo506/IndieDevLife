using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneScript : MonoBehaviour
{
    [SerializeField] Slider _progressSlider;
    [SerializeField] Text _tochText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingRoom());
    }

    IEnumerator LoadingRoom()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Room");

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            _progressSlider.value = asyncLoad.progress;

            if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                _progressSlider.gameObject.SetActive(false);
                _tochText.gameObject.SetActive(true);

                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
