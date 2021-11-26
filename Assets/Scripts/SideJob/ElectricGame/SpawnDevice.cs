using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDevice : MonoBehaviour
{
    [SerializeField] GameObject _parent;  // Родительский объект для прибора
    [SerializeField] GameObject[] _devicePrefabs;  // Префабы приборов
    GameObject currentDevice;

    public static SpawnDevice instance {get; private set;}

    private void Awake() {
        instance = this;
        Spawn();
    }

    // Метод спавна нового прибора для починки
    public void Spawn() {
        if (currentDevice != null) {
            Destroy(currentDevice);
        }

        currentDevice = Instantiate(_devicePrefabs[Random.Range(0, _devicePrefabs.Length)], _parent.transform);
    }
}
