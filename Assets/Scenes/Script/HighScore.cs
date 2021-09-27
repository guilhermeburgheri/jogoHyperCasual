using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText, finalScoreText;
    public bool finalScore, highScore;

    // Start is called before the first frame update
    void Start()
    {
        if(finalScore)
        {
            finalScoreText = GetComponent<Text>();
            finalScoreText.text = "" + PlayerPrefs.GetInt("finalScore");
        } 
        else if(highScore)
        {
            highScoreText = GetComponent<Text>();
            highScoreText.text = "" +  PlayerPrefs.GetInt("highScore");
        }
    }
}
