using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surviver : MonoBehaviour
{
    [SerializeField] GameObject _shootPrefab;
    public UnityEngine.UI.Button spawnButton;

    // Start is called before the first frame update
    void Start()
    {
        spawnButton.gameObject.SetActive(false);
        StartCoroutine(StartShooting());
    }

    IEnumerator StartShooting() {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(_shootPrefab, this.gameObject.transform.position, _shootPrefab.transform.rotation);
            yield return new WaitForSeconds(1f);
        }

        spawnButton.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
