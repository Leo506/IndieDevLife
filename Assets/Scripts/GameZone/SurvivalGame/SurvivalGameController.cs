using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalGameController : MonoBehaviour
{
    [SerializeField] GameObject _surviverPrefab;  // Префаб выживальщика
    [SerializeField] GameObject _victoryPanel, _gameOverPanel;  // Панели конца игры (победы и поражения)
    [SerializeField] Text _scoreText, _priceText;  // Текст со счётом и победным призом
    int score = 200;

    public static SurvivalGameController instance;


    private void Awake() {
        Time.timeScale = 0;
        instance = this;
    }


    private void Update() {
        SurvivalEnemy[] enemies = FindObjectsOfType<SurvivalEnemy>();

        if (enemies.Length == 0) Victory();
    }


    // Метод создания выживальщика в месте кнопки
    public void CreateSurviver(Transform transform, Button button) {
        var position = Camera.main.ScreenToWorldPoint(transform.position);
        position.z = 0;
        var sur = Instantiate(_surviverPrefab, position, Quaternion.identity);
        sur.GetComponent<Surviver>().spawnButton = button;
    }


    public void AddScore(int value) {
        score += value;
        _scoreText.text = score.ToString();
    }


    public int GetScore() { return score;}


    public void StartGame() {
        Time.timeScale = 1;
        Money.ChangeMoney(-100);
    }


    public void ReturnToHome() {
        SceneManager.LoadScene("Room");
    }


    // Конец игры (поражение)
    public void GameOver() {
        Time.timeScale = 0;
        _gameOverPanel.gameObject.SetActive(true);
    }


    // Победа
    public void Victory() {
        var price = 50 + (int)(score/2);
        _priceText.text = $"+{price}";
        Money.ChangeMoney(price);
        _victoryPanel.gameObject.SetActive(true);
    }
}
