using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    
    Vector3 pointPosition;       // Точка, к которой движется персонаж
    float YPos;
    static bool canMove = true;         // Булевая переменная, определяющая может ли игрок двигаться
    public static PlayerMovement instance;

    
    private void Awake() {
        Time.timeScale = 1;
        CanMove();
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        pointPosition = new Vector3(0, transform.position.y, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerInput.instance.HasPlayerInput() && canMove) {                                     
            pointPosition = PlayerInput.instance.GetPointPosition();
        }

        if (gameObject.GetComponent<CharacterController>().isGrounded) YPos = 0;  // Если игрок на земле, то по у не перемещаемся
        else YPos = -PlayerData.instance.gravity;                                                     // Если не на земле - скорость по у равна гравитации

        Vector3 movement = new Vector3(pointPosition.x - transform.position.x, YPos, pointPosition.z - transform.position.z) * PlayerData.instance.speed;

        if (canMove && pointPosition != Vector3.zero && !CheckPosition())
        {
            // Включаем анимацию
            PlayerData.instance.playerAnimator.SetBool("move", true);

            

            // Поворот в сторону движения
            var direction = pointPosition - transform.position;
            direction = new Vector3(direction.x, 0, direction.z);
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 8);

            // Движение персонажа
            GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        } else {
            // Если не двигаемся - выключаем анимацию
            PlayerData.instance.playerAnimator.SetBool("move", false);

            
        }
    }


    public void CanMove()
    {
        canMove = true;
        ZeroingPointPosition();
    }

    public void CantMove()
    {
        canMove = false;
    }

    public void ZeroingPointPosition() {
        pointPosition = Vector3.zero;
    }

    bool CheckPosition() {
        var pointX = Math.Round(pointPosition.x, 1);
        var pointZ = Math.Round(pointPosition.z, 1);

        var X = Math.Round(transform.position.x, 1);
        var Z = Math.Round(transform.position.z, 1);

        if ((pointX == X) && (pointZ == Z)) return true;
        
        return false;
    }
}