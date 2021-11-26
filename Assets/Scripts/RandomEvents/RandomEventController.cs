using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomEventController : MonoBehaviour
{
    [SerializeField] Canvas _randomEventCanvas;
    HackatonController hackaton;
    RentController rent;

    public static RandomEventController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartCoroutine("RandomEvent");
        hackaton = GetComponent<HackatonController>();
        rent = GetComponent<RentController>();
    }

    IEnumerator RandomEvent()
    {
        while (true)
        {
            var a = Random.Range(0, 10);
            if (a == 0)
            {
                // активация хакатона
                HackatonController.instance.StartHackatonScene();
            }

            if (a == 2 && Money.GetMoney() > 0) 
            {
                // Плата за квартиру
                RentController.instance.StartRentScene();
            }

            yield return new WaitForSeconds(30);
        }
        
    }
}
