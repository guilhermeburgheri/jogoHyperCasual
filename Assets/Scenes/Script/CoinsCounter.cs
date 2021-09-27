using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{

    Text coinsText; //texto do coins convertido da variável inteira coinsValue pega do PlayerPrefs
    public bool coinsAfterGame;
    
    void Start()
    {
        coinsText = GetComponent<Text>();
    }

    void Update()
    {
        if(coinsAfterGame)
        {
            coinsText.text = "" + PlayerPrefs.GetInt("Coins");
        } 
        else
        {
            coinsText.text = "Moedas: " + PlayerPrefs.GetInt("Coins");
        }
    }
}

