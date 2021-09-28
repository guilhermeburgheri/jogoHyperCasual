using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class colorToPrefab 
{
    private int percentageNumber;
    public GameObject goldPrefab, purplePrefab, redPrefab, greenPrefab, bluePrefab;
    public Color color;
    
    [HideInInspector]
    public GameObject prefab; 
    
    public void chooseCoin()
    {
        percentageNumber = Random.Range(1, 101);
        Debug.Log("Percentage Number: " + percentageNumber);
        if(percentageNumber >= 1 && percentageNumber < 61)
        {
                prefab = goldPrefab;
        }   
        if(percentageNumber >= 61 && percentageNumber < 80)
        {
                prefab = purplePrefab;
        }    
        if(percentageNumber >= 81 && percentageNumber < 90)
        {
                prefab = redPrefab;
        }
        if(percentageNumber >= 91 && percentageNumber < 98)
        {
                prefab = greenPrefab;
        }
        if(percentageNumber >= 98 && percentageNumber <= 100)
        {
                prefab = bluePrefab;
        }
        Debug.Log("Prefab: " + prefab);
    }
}

public class CoinSpawner : MonoBehaviour
{
    public Texture2D UAM_map, seta_map; /*circulo_map, skate_map, linha_map;*/
    public colorToPrefab[] _colorToPrefab;
    public GameObject parentObj;
    Texture2D coinMap;
    int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        //Iniciar a função TimeToGenerateMap como uma coroutine.
        StartCoroutine(TimeToGenerateMap(20f));
    }

    private IEnumerator TimeToGenerateMap(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            GenerateMap();
        } 
    }

    void GenerateMap()
    {
        randomNumber = Random.Range(1, 3);
        switch (randomNumber)
        {
            case 1:
            coinMap = UAM_map;
            break;

            case 2:
            coinMap = seta_map;
            break;
/*
            case 3:
            coinMap = circulo_map;
            break;

            case 4:
            coinMap = skate_map;
            break;

            case 5:
            coinMap = linha_map;
            break; 
            */  
        }

        for(int x = 0; x < coinMap.width; x++)
        {
            for(int y = 0; y < coinMap.height; y++)
            {
                GenerateCoins(x, y);
            }
        }
    }

    void GenerateCoins(int x, int y)
    {
        Color mapColor = coinMap.GetPixel(x, y);

        foreach(colorToPrefab obj in _colorToPrefab)
        {
            if(obj.color.Equals(mapColor))
            {
                Vector2 pos = new Vector2(x, y);
                obj.chooseCoin();
                Instantiate(obj.prefab, pos, Quaternion.identity, parentObj.transform);
            }
        }
    }

}
