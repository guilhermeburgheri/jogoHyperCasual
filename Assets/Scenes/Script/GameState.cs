 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public enum gameState
    {
        none,
        started,
        ended
    }

    public gameState sessionState = gameState.none;
    public bool gameIsRunning;
    public bool tentarNovamente;

    public Button btnJogar;
    public Button btnRetornar;
    public Button btnResetHighScore;
    public Button btnCredito;

    public Text highScoreText;

    void Start()
    {
        if(sessionState ==  gameState.ended || sessionState == gameState.none)
        {
            btnJogar.onClick.AddListener(PlayGame);
            
        } 
        if(sessionState == gameState.ended)
        {
            btnRetornar.onClick.AddListener(ReturnMenu);
            btnResetHighScore.onClick.AddListener(ResetHighScore);
        }
    }

    void PlayGame()
    {
       if(sessionState == gameState.ended) 
       {
         tentarNovamente = true;
       } 
       else
       {
        tentarNovamente = false;
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("finalScore", 0);
        PlayerPrefs.SetInt("finalDistance", 0);
        sessionState = gameState.started;
        HandleStates();
       } 
       if(tentarNovamente && PlayerPrefs.GetInt("Coins") >= 100)
        {
          int custoReinicio = PlayerPrefs.GetInt("Coins");
          custoReinicio -= 100;
          PlayerPrefs.SetInt("Coins", custoReinicio);
          sessionState = gameState.started;
          HandleStates();
        }
    }

   public void EndGame()
    {
        sessionState = gameState.ended;
        HandleStates();
    }

    void ReturnMenu()
    {
        sessionState = gameState.none;
        HandleStates();
    }

    void ResetHighScore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        PlayerPrefs.SetInt("highDistance", 0);
        highScoreText.text = "" +  PlayerPrefs.GetInt("highScore") + "/n" + PlayerPrefs.GetInt("highDistance"); 
    }

    void HandleStates()
    {
        switch (sessionState)
        {
            case gameState.none:
            SceneManager.LoadScene("MainMenu"); //carregar o Menu
            gameIsRunning = false;
            break;
            case gameState.started:
            SceneManager.LoadScene("SampleScene"); //carregar a cena do Jogo
            gameIsRunning = true; // declara que o jogo está rolando se o gameStated é de jogo iniciado. Essa boolean é pra verificações de condicionais de outros scripts.
            break;
            case gameState.ended:
            SceneManager.LoadScene("HighScore"); //carregar a cena de fim de jogo
            gameIsRunning = false; 
            break;
        }
    }
}
