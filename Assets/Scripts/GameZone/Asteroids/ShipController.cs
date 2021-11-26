using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    [SerializeField] Button _rightButton, _leftButton;  // Кнопки передвидвижения вправо и влево
    [SerializeField] GameObject _fire;  // Префаб выстрела
    [SerializeField] GameObject _gameOverPanel;
    public int speed;  // Скорость передвижения

    public float min_x, max_x;  // Максимальныое и минимальное положение коробля

    Rigidbody2D rig;

    float nextFireTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (_rightButton.GetComponent<MovementButton>().isPressed) {
            movement = new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

        if (_leftButton.GetComponent<MovementButton>().isPressed) {
            movement = new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }

        rig.velocity = movement;

        var x = Mathf.Clamp(transform.position.x, min_x, max_x);

        transform.position = new Vector3(x, transform.position.y, transform.position.z);

    }


    // Выстрел
    public void Fire() {
        if (Time.time >= nextFireTime) {
            Instantiate(_fire, transform.position, Quaternion.identity);
            nextFireTime = Time.time + 0.5f;
            Events.instance.Notify(EventTypes.SHOOT);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.tag == "Asteroid") {

            Events.instance.Notify(EventTypes.ASTEROID_LOSS);
            Events.instance.Notify(EventTypes.FAILED);
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
            Destroy(this.gameObject);

        }

    }
}
