using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0; // valor de pontos totais do score
    public float timeToIncreaseScore = 10f; //tempo em segundos para aumentar o score
    private float countTime;
    public int scoreIncrease = 10;
    Text scoreText; //texto do score convertido da variável inteira ScoreValue
    
    void Start()
    {
        scoreText = GetComponent<Text>();
        ScoreValue = PlayerPrefs.GetInt("finalScore");
    }

    void Update()
    {
        Timer();
        ScoreToText();
        HighScore();
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
            ScoreValue += scoreIncrease;
            countTime = 0;
        }
    }

    void HighScore()
    {
        //compare se o score é maior que o recorde, se for substitua o antigo recorde pelo novo.
        if(ScoreValue > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", ScoreValue);
        } 
        //salve o valor do score para exibir na tela final.
        PlayerPrefs.SetInt("finalScore", ScoreValue);
    }
}
