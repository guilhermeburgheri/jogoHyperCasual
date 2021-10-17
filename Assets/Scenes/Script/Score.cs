using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0; // valor de pontos totais do score
    public static int distanceValue = 0; 
    public float timeToIncreaseDistance = 10f; //tempo em segundos para aumentar a distância
    private float countDistance;
    public static int distanceDivision = 50; // a cada 50m aumente um de score
    public static int distanceLowerPoint = 5;
    public int distanceIncrease = 1;
    public float distanceMultiplier = 2f;
    public float timeToIncreaseAirScore = 1f;
    private float countAirScore;
    
    Text scoreText; //texto do score convertido da variável inteira ScoreValue
    Text distanceText; 

    GameObject playerObject;
    PlayerMovement playerMovementScript;

    public bool isDistanceText;
    private bool isDistanceIncreased;

    void Start()
    {
        if(isDistanceText) distanceText = GetComponent<Text>(); else scoreText = GetComponent<Text>();
        ScoreValue = PlayerPrefs.GetInt("finalScore");
        distanceValue = PlayerPrefs.GetInt("finalDistance");
        playerObject = GameObject.FindWithTag("Player");
        playerMovementScript = (PlayerMovement) playerObject.GetComponent(typeof(PlayerMovement));
    }

    void Update()
    {
        if(isDistanceText) DistanceToText(); else ScoreToText();
        DistanceCounter();
        HighScore();
        HighDistance();
        ScoreCounter();
    }

    void ScoreToText()
    {
        scoreText.text = "Score: " + ScoreValue;
    }

    void DistanceToText()
    {
        distanceText.text = "Distância: " + distanceValue + "m";
    }

    void ScoreCounter()
    {
        if(distanceValue % distanceDivision == 0 && distanceValue != 0 && isDistanceIncreased)
        {
           ScoreValue += 5;
        } 
        else if(distanceValue % distanceLowerPoint == 0 && distanceValue != 0 && isDistanceIncreased)
        {
            ScoreValue += 1;
        }
        else if(playerMovementScript.isJumping || playerMovementScript.isInObstacle)
        {
            if(countAirScore > 0)
            {
                countAirScore -= Time.deltaTime;
            }
            else 
            {
                ScoreValue += 1;
                countAirScore = timeToIncreaseAirScore;
            }
        }
    }

    void DistanceCounter() 
    {
        if(countDistance > 0)
        {
            countDistance -= Time.deltaTime;
            isDistanceIncreased = false;
        } 
        else 
        {
            isDistanceIncreased = true;
            distanceValue += 1;
            countDistance = timeToIncreaseDistance;
        }
    }

     void HighDistance()
    {
        if(distanceValue > PlayerPrefs.GetInt("highDistance"))
        {
            PlayerPrefs.SetInt("highDistance", distanceValue);
        } 
        PlayerPrefs.SetInt("finalDistance", distanceValue);
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
