using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    private void Awake() {
        instance = this;
    }

    // Метод возвращающий true, если было нажатие (не на элемент UI)
    public bool HasPlayerInput() {
        bool isInput = false;

        // Для телофонов
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                isInput = true;
                Events.instance.Notify(EventTypes.NORMAL_CLICK);
            }
        }

        // Для компьютера
        /*if (Input.GetMouseButtonDown(0))
        {

             if (!EventSystem.current.IsPointerOverGameObject())
             {
                 isInput = true;
                 Events.instance.Notify(EventTypes.NORMAL_CLICK);
             }
         }*/


        return isInput;
    }


    public Vector3 GetPointPosition() {
        Vector3 pointPosition = Vector3.zero;

        Camera cam;

        if (PlayerData.instance.mainCamera.gameObject.activeSelf) cam = PlayerData.instance.mainCamera;
        else return Vector3.zero;

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);   // Пускаем луч в точке нажатия
        if (Physics.Raycast(ray, out hit)) {                        // Если на пути луча был коллайдер
            pointPosition = new Vector3((float)Math.Round(hit.point.x, 1), hit.point.y, (float)Math.Round(hit.point.z, 1));
            
        }

        return pointPosition;
    }
}
