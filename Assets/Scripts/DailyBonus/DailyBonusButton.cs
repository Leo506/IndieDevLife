using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusButton : MonoBehaviour
{
    [SerializeField] int buttonIndex;
    [SerializeField] Text _price;
    Button itButton;

    // Start is called before the first frame update
    void Start()
    {
        itButton = GetComponent<Button>();

        if (buttonIndex == DailyBonusController.bonusIndex) {
            itButton.enabled = true;
            StartCoroutine(ChangePriceColor());
        } else {
            itButton.enabled = false;
        }
    }

    IEnumerator ChangePriceColor() {
        var startColor = _price.color;
        
        while (true) {
            _price.color = startColor;
            yield return new WaitForSeconds(0.5f);

            _price.color = Color.red;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
