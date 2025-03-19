using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorn : MonoBehaviour
{
    public GameObject[] prefabs; 
    public Transform imageTarget;  
    
    public float times = 0;
    public float boomTime = 0;
    
    
    void Update()
    {
        times += Time.deltaTime;
        boomTime += Time.deltaTime;
        if(20 < timer.gameTime && timer.gameTime <= 30)
        {
            if(times >= 1.5)
            {
                Spawncorn();
                times = 0;
            }
            if(boomTime >= 2.5)
            {
                SpawnBoom();
                boomTime = 0;
            } 
        }else if(10 < timer.gameTime && timer.gameTime <= 20)
        {
            if(times >= 1)
            {
                Spawncorn();
                times = 0;
            }
            if(boomTime >= 2)
            {
                SpawnBoom();
                boomTime = 0;
            }
        }else if(timer.gameTime <= 10)
        {
            if(times >= 0.5)
            {
                Spawncorn();
                times = 0;
            }
            if(boomTime >= 1)
            {
                SpawnBoom();
                boomTime = 0;
            }
        }
        
    
    }

    void Spawncorn()
    {
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomZ = Random.Range(-0.03f, 0.03f);
        Vector3 spawnPos = new Vector3(randomX,0,randomZ) + imageTarget.position;

        
        GameObject corn = Instantiate(prefabs[0], spawnPos, Quaternion.identity);
        corn.transform.SetParent(imageTarget); 
        Destroy(corn,1.5f);
    }
    void SpawnBoom(){
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomZ = Random.Range(-0.03f, 0.03f);
        Vector3 spawnPos = new Vector3(randomX,0,randomZ) + imageTarget.position;

        GameObject bomb = Instantiate(prefabs[1], spawnPos, Quaternion.identity);
        bomb.transform.SetParent(imageTarget); 
        Destroy(bomb,1.5f);
    }
}
