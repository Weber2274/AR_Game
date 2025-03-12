using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorn : MonoBehaviour
{
    public GameObject molePrefab; 
    public Transform imageTarget;  
    public float spawnTime = 2.0f;  

    private float timer = 0f;  

    void Update()
    {
        timer += Time.deltaTime; 

        if (timer >= spawnTime) 
        {
            SpawnMole();
            timer = 0f; 
        }
    }

    void SpawnMole()
    {
        float randomX = Random.Range(-0.03f, 0.03f);
        float randomZ = Random.Range(-0.03f, 0.03f);
        Vector3 spawnPos = new Vector3(randomX, 0, randomZ) + imageTarget.position;

        
        GameObject corn = Instantiate(molePrefab, spawnPos, Quaternion.identity);
        corn.transform.SetParent(imageTarget); 
        Destroy(corn, 2.0f);
    }
}
