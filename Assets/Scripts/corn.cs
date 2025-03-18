using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class corn : MonoBehaviour
{
    public static int scores = 0;
    public Text scoreText;
    
    
    
    void OnMouseDown()
    {
        if(CompareTag("corn")){
            scores += 10;
        }else if(CompareTag("bomb")){
            scores -= 20;
        }

        if(scores < 0){
            scores = 0;
        }
        scoreText.text = "Score: " + scores;
        Destroy(gameObject);
    }
}
