using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkController : CanvasController
{
    static int _numberOfSideJob = 0;
    public static int NumberOfSideJob
    {
        get { return _numberOfSideJob; }
    }

    public void StartSideJob(string jobSceneName)
    {
        _numberOfSideJob++;
        Events.instance.Notify(EventTypes.GO_TO_WORK);
        SceneManager.LoadScene(jobSceneName);
    }

    // Start is called before the first frame update
    void Start()
    {
        thisCanvas = GetComponent<Canvas>();
    }

    protected override void FirstNotify()
    {
        Events.instance.Notify(EventTypes.CANVAS_ENABLE);
        Events.instance.Notify(EventTypes.ENTER);
    }

    protected override void SecondNotify()
    {
        Events.instance.Notify(EventTypes.CANVAS_DISABLE);
        Events.instance.Notify(EventTypes.EXIT);
    }
}
