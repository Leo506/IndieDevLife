using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadController : MonoBehaviour
{
    private void OnApplicationFocus(bool focusStatus) {
        if (!focusStatus) {
            SaveLoad.Save();
        } else {
            SaveLoad.Load();
        }
    }
}
