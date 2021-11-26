using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Определяем с каким объектом столкнулся персонаж и в зависимости от этого включаем определённые Canvas'ы
    private void OnTriggerEnter(Collider other) {
        switch (other.gameObject.name)
        {
            
            case "Table":
                PlayerActions.instance.SitDown();
                break;

            case "Bed":
               PlayerActions.instance.Sleep();
                break;

            case "Fridge":
                PlayerActions.instance.OpenFridge();
                break;

            case "Door":
                PlayerActions.instance.EnterAndExit(true);
                break;

            case "Market":
                PlayerActions.instance.GoToMarket();
                break;

            case "Publisher":
                PlayerActions.instance.GoToPublisher();
                break;

            case "Home":
                PlayerActions.instance.EnterAndExit(false);
                break;

            case "EmploymentCenter":
                PlayerActions.instance.GoToEmploymentCenter();
                break;

            case "GameZone":
                PlayerActions.instance.GoToGameZone();
                break;

            case "Cafe":
                PlayerActions.instance.GoToCafe();
                break;
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.name == "Table")
    //     {
    //        PlayerActions.instance.StandUp();
    //     }
    // }
}
