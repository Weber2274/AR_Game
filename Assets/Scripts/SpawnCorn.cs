using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorn : MonoBehaviour
{
    public GameObject[] prefabs; 
    public Transform imageTarget;  
    
    public float times = 0,maxTime = 2;
    public float boomTime = 0,boomMaxTime = 3;
    
    
    void Update()
    {
        times += Time.deltaTime;
        boomTime += Time.deltaTime;
        if(times >= 2)
        {
            Spawncorn();
            times = 0;
        }
        if(boomTime >= 3)
        {
            SpawnBoom();
            boomTime = 0;
        }
    
    }

    void Spawncorn()
    {
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomZ = Random.Range(-0.03f, 0.03f);
        Vector3 spawnPos = new Vector3(randomX,0,randomZ) + imageTarget.position;

        
        GameObject corn = Instantiate(prefabs[0], spawnPos, Quaternion.identity);
        corn.transform.SetParent(imageTarget); 
        Destroy(corn, 2.0f);
    }
    void SpawnBoom(){
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomZ = Random.Range(-0.03f, 0.03f);
        Vector3 spawnPos = new Vector3(randomX,0,randomZ) + imageTarget.position;

        GameObject corn = Instantiate(prefabs[1], spawnPos, Quaternion.identity);
        corn.transform.SetParent(imageTarget); 
        Destroy(corn, 2.0f);
    }
}
