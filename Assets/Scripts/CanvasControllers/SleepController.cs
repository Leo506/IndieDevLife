using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepController : CanvasController
{
    [SerializeField] Image _night;

    // Start is called before the first frame update
    void Start()
    {
        thisCanvas = GetComponent<Canvas>();
    }

    protected override void FirstNotify()
    {
        Events.instance.Notify(EventTypes.GO_TO_BED);
    }

    protected override void SecondNotify()
    {
        Events.instance.Notify(EventTypes.UP_FROM_BED);
    }

    public void StartSleep()
    {
        _night.gameObject.SetActive(true);
        StartCoroutine("Sleeping");
    }

    IEnumerator Sleeping()
    {
        Events.instance.Notify(EventTypes.SLEEPING);

        // Затемнение
        for (int i = 0; i <= 100; i++)
        {
            _night.color = new Color(0, 0, 0, (float)i / 100);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(3);


        Events.instance.Notify(EventTypes.WAKE_UP);


        // Просветление
        for (int i = 100; i >= 0; i--)
        {
            _night.color = new Color(0, 0, 0, (float)i / 100);
            yield return new WaitForSeconds(0.025f);
        }

        _night.gameObject.SetActive(false);
        Sleep.ChangeSleepValue(50);
        DisableThisCanvas();
        PlayerMovement.instance.CanMove();
    }
}
