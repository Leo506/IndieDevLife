using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddController : MonoBehaviour
{
    public static bool addIsAvailible = true;

    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4243545", false);
        }
    }

    public void TryShowAdd()
    {
        if (Advertisement.IsReady() && addIsAvailible)
        {
            Advertisement.Show("Rewarded_Android");
            
        }
    }
}
