using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score;
    private int highScore;

    public Text scoreText;
    public Text highScoreText;
    public Button replayButton;
    public Button backButton;
    public GameObject panel;

    private int curScore;
    public int distance = 30;
    public bool isExistsFood;
    public float horizontalRange;
    public float verticalRange;

    public GameObject foodPref;

    private void Start()
    {
        panel.SetActive(false);
        score = 0;
        curScore = 0;
        isExistsFood = false;
        scoreText.text = "SCORE: 0";
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int scoreChange)
    {
        score += scoreChange;
        scoreText.text = "SCORE: " + score.ToString();
        if (score - curScore >= distance && isExistsFood == false) SpawnFood();
    }

    public void SetTextHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
        highScoreText.text = "HIGH SCORE: " + highScore.ToString();
    }
    public void RestartGame()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnFood()
    {
        isExistsFood = true;
        float horizontalPos = Random.Range(-horizontalRange, horizontalRange);
        float verticalPos = Random.Range(-verticalRange, verticalRange);
        Vector3 spawnPosition = new Vector3(horizontalPos, 0, verticalPos);
        Instantiate(foodPref, spawnPosition, foodPref.transform.rotation);
    }
    public void SetCurScore()
    {
        curScore = score;
    }

}
