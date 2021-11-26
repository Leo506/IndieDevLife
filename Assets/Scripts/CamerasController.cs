using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] Camera _createGameCamera;

    public static CamerasController instance;

    private void Awake() {
        instance = this;
    }

    // Смена камер
    public void ChangeCamera() {
        _mainCamera.gameObject.SetActive(!_mainCamera.gameObject.activeSelf);
        _createGameCamera.gameObject.SetActive(!_createGameCamera.gameObject.activeSelf);
    }
}
