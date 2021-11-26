using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalBattleField : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") SurvivalGameController.instance.GameOver();
    }
}
