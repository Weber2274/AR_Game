using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class corn : MonoBehaviour
{
    public static int scores = 0; // 用於記錄遊戲分數
    public Text scoreText; // 用於顯示分數
    // 當玩家點擊物件時觸發
    void OnMouseDown()
    {
        // 檢查遊戲是否結束
        if(!timer.isGameOver)
        {
            // 檢查被點擊的物件的標籤
            if(CompareTag("corn"))
            {
                scores += 10; // 如果點擊的是果實生物，分數加10
            }
            else if(CompareTag("bomb"))
            {
                scores -= 20; // 如果點擊的是炸彈，分數減20
            }
            // 確保分數不會低於0
            if(scores < 0)
            {
                scores = 0;
            }
        }
        // 更新UI上的分數顯示
        scoreText.text = "Score: " + scores;
        // 銷毀被點擊的物件
        Destroy(gameObject);
    }
}
