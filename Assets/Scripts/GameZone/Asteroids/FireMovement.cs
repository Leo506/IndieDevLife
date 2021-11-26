using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    Rigidbody2D rig;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector3(0, speed, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Asteroid") {
            GameZoneSceneController.instance.UpdateScore();
            Events.instance.Notify(EventTypes.ASTEROID_HIT);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
