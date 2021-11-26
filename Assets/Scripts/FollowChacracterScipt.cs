using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChacracterScipt : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Camera _camera1, _camera2;
    Vector3 distance;

    private void Awake() {
        try {
            distance = Camera.main.WorldToScreenPoint(_player.transform.position) - transform.position;
        } catch {
            try {
                distance = _camera1.WorldToScreenPoint(_player.transform.position) - transform.position;
            } catch {
                distance = _camera2.WorldToScreenPoint(_player.transform.position) - transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        try {
            transform.position = Camera.main.WorldToScreenPoint(_player.transform.position) - distance;
        } catch {
            try {
                transform.position = _camera1.WorldToScreenPoint(_player.transform.position) - distance;
            } catch {
                transform.position = _camera2.WorldToScreenPoint(_player.transform.position) - distance;
            }
            
        }
        
    }
}
