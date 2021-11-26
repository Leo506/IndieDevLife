using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
    //PlayerMovement playerMovement;
    public static PlayerActions instance;

    private void Awake() {
        //playerMovement = GetComponent<PlayerMovement>();
        instance = this;
    }

    // Метод сидения за столом
    public void SitDown() {
        PlayerMovement.instance.CantMove();
        transform.position = new Vector3(3.471f, 0.08417752f, 3.87f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        PlayerData.instance.playerAnimator.SetBool("standUp", false);
        PlayerData.instance.playerAnimator.SetBool("sitDown", true);
        StartCoroutine(WaitingSitAnimation());
    }


    // Подъём из-за стола
    public void StandUp() {
        PlayerData.instance.playerAnimator.SetBool("standUp", true);
        PlayerData.instance.playerAnimator.SetBool("sitDown", false);
        PlayerData.instance.playerAnimator.SetBool("move", false);
        StartCoroutine(WaitingStandAnimation());
    }


    // Метод сна
    public void Sleep() {
        PlayerData.instance.sleepCanvas.GetComponent<CanvasController>().EnableThisCanvas();
        PlayerMovement.instance.CantMove();
    }


    // Метод открытия холодильника
    public void OpenFridge() {
        PlayerData.instance.fridgeCanvas.GetComponent<CanvasController>().EnableThisCanvas();
        PlayerMovement.instance.CantMove();
    }


    // Метод выхода на улицу (возвращение домой)
    public void EnterAndExit(bool goToStreet) {
        if (goToStreet) {
            SceneManager.LoadScene("NewTown");
            Events.instance.Notify(EventTypes.EXIT);
        } else {
            SceneManager.LoadScene("LoadingScene");
            Events.instance.Notify(EventTypes.ENTER);
        }
    }


    // Метод похода в магазин
    public void GoToMarket() {
        SceneManager.LoadScene("Market");
    }


    // Метод похода к издателю
    public void GoToPublisher() {
        PlayerData.instance.publisherCanvas.GetComponent<CanvasController>().EnableThisCanvas();
        PlayerMovement.instance.CantMove();
    }


    // Метод похода в центр занятости
    public void GoToEmploymentCenter() {
        PlayerData.instance.workCanvas.GetComponent<CanvasController>().EnableThisCanvas();
        PlayerMovement.instance.CantMove();;
    }



    // Поход в геймзону
    public void GoToGameZone() {
        PlayerData.instance.gameZoneCanvas.GetComponent<CanvasController>().EnableThisCanvas();
        PlayerMovement.instance.CantMove();
    }


    // Поход в кафе
    public void GoToCafe()
    {
        PlayerData.instance.cafeCanvas.GetComponent<CanvasController>().EnableThisCanvas();
        PlayerMovement.instance.CantMove();
    }


    



    IEnumerator WaitingSitAnimation() {
        yield return new WaitForSeconds(2.5f);

        CamerasController.instance.ChangeCamera();
        PlayerData.instance.computerCanvas.GetComponent<CanvasController>().EnableThisCanvas();
    }


    IEnumerator WaitingStandAnimation() {
        CamerasController.instance.ChangeCamera();
        PlayerData.instance.computerCanvas.GetComponent<CanvasController>().DisableThisCanvas();

        yield return new WaitForSeconds(2.5f);

        PlayerMovement.instance.ZeroingPointPosition();
        PlayerMovement.instance.CanMove();
    }
}
