using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource itSource { get; private set; }
    [SerializeField] AudioSource secondSource;
    AssetBundle music;

    private void Awake() {
        MusicController[] objs = FindObjectsOfType<MusicController>();

        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);

        itSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        music = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/AssetBundles/music");
    }

    public void On() {
        if (!itSource.isPlaying)
            itSource.Play();
    }

    public void Off() {
        itSource.Pause();
    }

    public void ChangeMusic(string musicName)
    {
        if (SettingsController.musicIsOn)
            StartCoroutine(FadeInOut(musicName));
    }

    public void SetStandartMusic()
    {
        if (SettingsController.musicIsOn)
            StartCoroutine(StandartMusic());
    }

    IEnumerator FadeInOut(string musicName)
    {
        float fadePerIteration = itSource.volume / 100;
        AudioClip newClip = music.LoadAsset(musicName) as AudioClip;

        for (int i = 0; i < 100; i++)
        {
            itSource.volume -= fadePerIteration;
            yield return new WaitForSeconds(0.01f);
        }

        itSource.Pause();
        secondSource.clip = newClip;
        secondSource.Play();

        for (int i = 0; i < 100; i++)
        {
            secondSource.volume += fadePerIteration;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator StandartMusic()
    {
        float fadePerIteration = secondSource.volume / 100;

        for (int i = 0; i < 100; i++)
        {
            secondSource.volume -= fadePerIteration;
            yield return new WaitForSeconds(0.01f);
        }

        secondSource.Stop();
        itSource.Play();

        for (int i = 0; i < 100; i++)
        {
            itSource.volume += fadePerIteration;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
