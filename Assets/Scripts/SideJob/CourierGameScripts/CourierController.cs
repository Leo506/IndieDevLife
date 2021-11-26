using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourierController : MonoBehaviour
{
    [SerializeField] Joystick _joystic;  // Джойстик управления
    [SerializeField] UnityEngine.UI.Image _packageImage;
    [SerializeField] Animator _animator;
    CharacterController _character;  // Ссылка на компонент CharacterController
    public float speed;  // Скорость персонажа

    float vertSpeed = -3;  // Скорость по вертикали (или гравитация)

    packageColor colorOfPackage;

    Vector3 lastPos;


    // Start is called before the first frame update
    void Start()
    {
        colorOfPackage = packageColor.Null;
        _character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Движение персонажа
        var hor = _joystic.Horizontal * speed;
        var vert = _joystic.Vertical * speed;
        Vector3 movement = new Vector3(hor, vertSpeed, vert) * Time.deltaTime;
        _character.Move(movement);

        if (_joystic.Horizontal != 0 && _joystic.Vertical != 0)
            _animator.SetBool("move", true);
        else
            _animator.SetBool("move", false);

        var direction = lastPos - transform.position;
        if (direction != Vector3.zero)
        {
            direction = new Vector3(direction.x, 0, direction.z);
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 20);
            lastPos = transform.position;
        }
        
    }


    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Office") {
            GetPackage();
        }

        if (hit.gameObject.tag == "DeliveryTarget") {
            if (hit.gameObject.GetComponent<DeliveryTargetClass>().color == colorOfPackage) {
                DeliveryPackage();
            }
        }
    }


    // Метод получения посылки курьером из офиса 
    public void GetPackage() {
        if (!GameController.instance.gameOver && colorOfPackage == packageColor.Null) {
            colorOfPackage = OfficeController.instance.currentPackage.GetComponent<PackageClass>().color;
            Debug.Log(colorOfPackage);
            UpdatePackageImage();
            Destroy(OfficeController.instance.currentPackage);
            Events.instance.Notify(EventTypes.GET_PACKAGE);
        }
    }


    // Метод доставки посылки
    void DeliveryPackage() {
       GameController.instance.packageIsDelivered = true;
       GameController.instance.UpdateScore();
       colorOfPackage = packageColor.Null;
       UpdatePackageImage();
       Debug.Log("Посылка успешно доставлена!");
       Events.instance.Notify(EventTypes.PUT_PACKAGE);
    }

    // Метод обновления изображения посылки
    void UpdatePackageImage() {
        switch (colorOfPackage)
        {
            
            case packageColor.Orange: 
                _packageImage.color = new Color(0.9f, 0.5f, 0.2f, 1);
                break;
            case packageColor.Yellow:
                _packageImage.color = Color.yellow;
                break;
            case packageColor.Green:
                _packageImage.color = Color.green;
                break;
            case packageColor.Blue:
                _packageImage.color = Color.blue;
                break;
            case packageColor.Null:
                _packageImage.color = Color.white;
                break;
        }
    }
}
