using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentController : MonoBehaviour
{
    [SerializeField] GameObject _paymentPanel;  // Панель оплаты аренды
    [SerializeField] GameObject _tenantPrefab;  // Префаб арендодателя
    GameObject tenant;

    public static RentController instance;

    private void Awake() {
        instance = this;
    }


    // Начинаем сцену с арендой
    public void StartRentScene() {
        Debug.Log("Старт сцены с арендой");

        if (UIController.IsPlayerInUI()) {  // Если игрок находиться в каком-то UI, то ждём
            StartCoroutine(Waiting());
        } else {
            PlayerMovement.instance.CantMove();
            tenant = Instantiate(_tenantPrefab);
        }
    }


    // Показываем панель оплаты аренды 
    public void ShowPaymentText() {
        PlayerMovement.instance.CantMove();
        _paymentPanel.SetActive(true);
    }


    // Оплата аренды
    public void Pay() {
        Money.ChangeMoney(-1000, false);
        Destroy(tenant.gameObject);

        PlayerMovement.instance.CanMove();
        _paymentPanel.SetActive(false);
    }

    IEnumerator Waiting() {
        yield return new WaitUntil(() => !UIController.IsPlayerInUI());
        PlayerMovement.instance.CantMove();
        tenant = Instantiate(_tenantPrefab);
    }

    
}
