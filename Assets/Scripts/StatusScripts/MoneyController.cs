using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text _moneyText, _floppyDiskText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       try
       {
            _moneyText.text = Money.GetMoney().ToString();
            _floppyDiskText.text = Money.GetFloppyDisks().ToString();
       }
       catch (System.Exception)
       {
           
           return;
       }
    }

    // Метод оплаты квартиры
    public void Pay(int value)
    {
        Money.ChangeMoney(-value);
        Destroy(FindObjectOfType<TenantMovement>().gameObject);
    }
}
