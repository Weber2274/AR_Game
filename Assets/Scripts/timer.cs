using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text times;
    public Text scoreText;
    public Text gameOverText;
    public Button restartButton;
    public Button startButton;
    public float gameTime = 30f;
    
    void Start()
    {
        Time.timeScale = 0f;
        restartButton.gameObject.SetActive(false);

    }
    
    void Update()
    {
        gameTime -= Time.deltaTime;
        times.text = "Time: " + Mathf.Ceil(gameTime);
        if(gameTime <= 0)
        {
            GameOver();
            restartButton.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        startButton.gameObject.SetActive(false); 
        restartButton.gameObject.SetActive(false); 
        Time.timeScale = 1f;  
        times.text = "Time: 30";
        scoreText.text = "Score: 0";
    }
    void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = corn.scores.ToString() + "分";
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        gameTime = 30f;
        times.text = "Time: 30";
        Time.timeScale = 1f;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        scoreText.text = "Score: 0";
        corn.scores = 0;
    }
}
