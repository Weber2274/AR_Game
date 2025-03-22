using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    public Text times; // 顯示剩餘時間
    public Text scoreText; // 顯示分數
    public Text gameOverText; // 遊戲結束時顯示分數
    public Button restartButton; // 重新開始遊戲的按鈕
    public Button startButton; // 開始遊戲的按鈕
    public static float gameTime = 20f; // 遊戲總時間，初始值為20秒
    public static bool isGameOver = false; // 遊戲是否結束的標誌
    void Start()
    {
        Time.timeScale = 0f; // 遊戲開始時暫停遊戲
        restartButton.gameObject.SetActive(false); // 隱藏重新開始按鈕
    }
    void Update()
    {
        // 每幀減少遊戲時間
        gameTime -= Time.deltaTime;
        // 更新UI上的剩餘時間顯示，使用Mathf.Ceil將時間取整數
        times.text = "Time: " + Mathf.Ceil(gameTime);
        // 如果遊戲時間小於等於0，觸發遊戲結束
        if(gameTime <= 0)
        {
            GameOver(); // 呼叫遊戲結束方法
            restartButton.gameObject.SetActive(true); // 顯示重新開始按鈕
        }
    }
    // 開始遊戲的方法
    public void StartGame()
    {
        startButton.gameObject.SetActive(false); // 隱藏開始按鈕
        restartButton.gameObject.SetActive(false); // 隱藏重新開始按鈕
        Time.timeScale = 1f;  // 恢復遊戲時間流動
        times.text = "Time: 20"; // 重置時間顯示
        scoreText.text = "Score: 0"; // 重置分數顯示
    }
    // 遊戲結束的方法
    void GameOver()
    {
        isGameOver = true; // 設置遊戲結束為true
        gameOverText.gameObject.SetActive(true); // 顯示遊戲結束的文字
        gameOverText.text = corn.scores.ToString() + "分"; // 顯示最終分數
        Time.timeScale = 0f; // 暫停遊戲
    }
    // 重新開始遊戲的方法
    public void RestartGame()
    {
        isGameOver = false; // 重置遊戲結束
        gameTime = 20f; // 重置遊戲時間
        times.text = "Time: 20"; // 重置時間顯示
        Time.timeScale = 1f; // 恢復遊戲時間流動
        gameOverText.gameObject.SetActive(false); // 隱藏遊戲結束的文字
        restartButton.gameObject.SetActive(false); // 隱藏重新開始按鈕
        scoreText.text = "Score: 0"; // 重置分數顯示
        corn.scores = 0; // 重置分數
    }
}
