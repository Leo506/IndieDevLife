using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set;}

    [Header("Камеры")]
    public Camera mainCamera;
    public Camera secondCamera;

    [Header("Canvas'ы")]
    public Canvas computerCanvas; 
    public Canvas sleepCanvas; 
    public Canvas fridgeCanvas; 
    public Canvas publisherCanvas; 
    public Canvas workCanvas; 
    public Canvas gameZoneCanvas; 
    public Canvas skillsCanvas;
    public Canvas cafeCanvas;

    [Header("Свойства игрока")]
    public float speed = 0.5f;   // Скорость передвижения
    public float gravity = 10f;         // Значение гравитации

    [Header("Аниматор игрока")]
    public Animator playerAnimator;

    

    private void Awake() {
        instance = this;
    }
}
