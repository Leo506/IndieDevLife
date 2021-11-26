using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalEnemy : MonoBehaviour
{
    public float speed;

    Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        rig.velocity = new Vector2(speed, 0) * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Shoot") {

            SurvivalGameController.instance.AddScore(20);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
