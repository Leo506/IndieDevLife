using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClass : MonoBehaviour
{
    Sprite trueSprite;  // Изображение на перевороте карты
    [SerializeField] Sprite backSprite;  // Задняя часть карты
    Image cardImage;
    ProgrammerGameController controller;

    public bool isHidden;  // Булевая переменная, определяющая скрыта карта(задняя часть видна) или нет
    
    private void Start() {
        cardImage = GetComponent<Image>();
        isHidden = true;
        controller = FindObjectOfType<ProgrammerGameController>();
    }
    public void SetCardSprite(Sprite spr) {
        trueSprite = spr;
    }


    // При нажатии на карту она переворачивается
    public void OnClick() {
        if (isHidden) {
            Events.instance.Notify(EventTypes.CARD_CLICK);
            if (controller.GetCountOfOpenCards() < 2) {
                cardImage.sprite = trueSprite;
                isHidden = false;
                controller.Check(cardImage);
            }
            
        }
    }

    IEnumerator ShowCard() {
        yield return new WaitForSeconds(3);
        cardImage.sprite = backSprite;
        isHidden = true;
    }

    public void CloseCard() {
        StopCoroutine("ShowCard");
        cardImage.sprite = backSprite;
        isHidden = true;
    }
}
