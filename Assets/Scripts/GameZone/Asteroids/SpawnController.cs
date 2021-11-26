using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] _asteroids;  // Префаб астероида
    ShipController ship;
    public float maxX, minX;

    // Start is called before the first frame update
    void Start()
    {
        ship = FindObjectOfType<ShipController>();
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning() {
        while (ship != null)
        {
            var asteroid = _asteroids[Random.Range(0, _asteroids.Length)];

            var x = Random.Range(minX, maxX);
            var pos = new Vector3(x, asteroid.transform.position.y, asteroid.transform.position.z);

            Instantiate(asteroid, pos, Quaternion.identity);

            yield return new WaitForSeconds(1.5f);   
        }
    }
}
