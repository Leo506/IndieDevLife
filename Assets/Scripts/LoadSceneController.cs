using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    public static LoadSceneController instance;

    private void Awake() {
        instance = this;
    }

    public void LoadSceneByName(string sceneName) {
        UIController.playerInUI = false;
        SceneManager.LoadScene(sceneName);
    }
}
