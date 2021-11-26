using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidClass : MonoBehaviour
{
    Rigidbody2D rig;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(0, -speed) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        rig.AddForce(new Vector2(0, -speed) * Time.deltaTime);
    }
}
