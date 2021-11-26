using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    List<IObserver> observers;

    public static Events instance { get; private set; }

    public void AddObserver(IObserver obs)
    {
        observers.Add(obs);
    }

    private void Awake()
    {
        observers = new List<IObserver>();
        instance = this;
    }

    
    public void Notify(EventTypes eventType)
    {
        foreach (var item in observers)
        {
            item.OnNotify(eventType);
        }
    }
}
