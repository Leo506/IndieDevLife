using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenantMovement : MonoBehaviour
{
    bool move = true;

    PlayerMovement target;
    CharacterController characterController;
    [SerializeField] Animator _animator;

    float yPos;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        target = FindObjectOfType<PlayerMovement>();
        _animator.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (characterController.isGrounded) yPos = 0;
            else yPos = -10f;

            Vector3 movement = new Vector3(target.transform.position.x - transform.position.x, yPos, target.transform.position.z - transform.position.z) * 0.5f;
            characterController.Move(movement * Time.deltaTime);

        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            RentController.instance.ShowPaymentText();
            move = false;
            _animator.SetBool("isMoving", false);
        }
    }
}
