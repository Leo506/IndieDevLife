using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    [SerializeField] GameObject[] _packagePrefabs;  // Префабы посылок
    public packageColor packageColor;  // Цвет посылки

    public GameObject currentPackage;  // Текущая посылка

    public static OfficeController instance {get; private set;}


    private void Awake() {
        instance = this;
    }

    private void Update() {

        // Если игра не закончена и посылка была доставлена - спавним новую
        if (!GameController.instance.gameOver && GameController.instance.packageIsDelivered) {
            SpawnPackage();
        }
    }


    // Метод спавна посылки
    void SpawnPackage() {
        currentPackage = Instantiate(_packagePrefabs[Random.Range(0, _packagePrefabs.Length)], transform);
        GameController.instance.packageIsDelivered = false;
    }
}
