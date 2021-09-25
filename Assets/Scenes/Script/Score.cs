using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0; // valor de pontos totais do score
    public float timeToIncreaseScore = 5f; //tempo em segundos para aumentar o score
    private float countTime;
    Text scoreText; //texto do score convertido da variável inteira ScoreValue
    
    void Start()
    {
        scoreText = GetComponent<Text>();

    }

    
    void Update()
    {
        Timer();
        ScoreToText();
    }

    void ScoreToText()
    {
        scoreText.text = "Score: " + ScoreValue;
    }

    void Timer()
    {
        countTime += Time.deltaTime;
        if(countTime > timeToIncreaseScore)
        {
            ScoreValue += 1;
            countTime = 0;
        }
    }
}
