using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnCorn : MonoBehaviour
{
    public GameObject[] prefabs; // 存放果實生物與炸彈的Prefab
    public Transform imageTarget;  // image target的位置
    public float times = 0; // 用於計算果實生物的生成間隔時間
    public float boomTime = 0; // 用於計算炸彈的生成間隔時間
    void Update()
    {
        // 每幀增加時間
        times += Time.deltaTime; 
        boomTime += Time.deltaTime;
        // 根據遊戲時間的不同階段，調整果實生物和炸彈的生成間隔
        if(10 < timer.gameTime && timer.gameTime <= 20)
        {
            // 果實生物1秒生成一次，並重置計時器
            if(times >= 1)
            {
                Spawncorn();
                times = 0;
            }
            // 炸彈2秒生成一次，並重置計時器
            if(boomTime >= 2)
            {
                SpawnBoom();
                boomTime = 0;
            }
        }
        else if(timer.gameTime <= 10)
        {
            // 果實生物0.5秒生成一次，並重置計時器
            if(times >= 0.5)
            {
                Spawncorn();
                times = 0;
            }
            // 炸彈1秒生成一次，並重置計時器
            if(boomTime >= 1)
            {
                SpawnBoom();
                boomTime = 0;
            }
        }
    }
    // 生成果實生物的方法
    void Spawncorn()
    {
        // 隨機生成X和Z軸的範圍
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomZ = Random.Range(-0.03f, 0.03f);
        // 計算生成位置，基於Image Target的位置加上隨機偏移
        Vector3 spawnPos = new Vector3(randomX,0,randomZ) + imageTarget.position;
        // 實例化果實生物Prefab，並設置其位置
        GameObject corn = Instantiate(prefabs[0], spawnPos, Quaternion.identity);
        // 將生成的果實生物設置為Image Target的子物件
        corn.transform.SetParent(imageTarget); 
        // 1秒後銷毀果實生物
        Destroy(corn,1f);
    }
    // 生成炸彈的方法
    void SpawnBoom(){
        // 隨機生成X和Z軸的範圍
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomZ = Random.Range(-0.03f, 0.03f);
        // 計算生成位置，基於Image Target的位置加上隨機偏移
        Vector3 spawnPos = new Vector3(randomX,0,randomZ) + imageTarget.position;
        // 實例化炸彈Prefab，並設置其位置
        GameObject bomb = Instantiate(prefabs[1], spawnPos, Quaternion.identity);
        // 將生成的炸彈設置為Image Target的子物件
        bomb.transform.SetParent(imageTarget); 
        // 1秒後銷毀炸彈
        Destroy(bomb,1f);
    }
}
