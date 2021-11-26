using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalSpawn : MonoBehaviour
{
    [SerializeField] float[] _availableYPos;
    [SerializeField] GameObject _enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());        
    }

    
    IEnumerator StartSpawning() {
        for (int i = 0; i < 30; i++)
        {
            var yPos = _availableYPos[Random.Range(0, _availableYPos.Length)];
            var enemy = Instantiate(_enemyPrefab, new Vector2(transform.position.x, yPos), Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }
    }
}
