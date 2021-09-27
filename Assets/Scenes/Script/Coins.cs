using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coins : MonoBehaviour
{

    public float speed = 1.0f;
    private Vector2 screensBounds;
    Rigidbody2D rb;
    
    public int coinsValue;
    public bool goldCoin, blueCoin, redCoin, purpleCoin, greenCoin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screensBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        coinsValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screensBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(goldCoin)
            {
                coinsValue += 1;
            }
            else if(blueCoin)
            {
                coinsValue += 5;
            }
            else if(redCoin)
            {
                coinsValue += 3;
            }
            else if(purpleCoin)
            {
                coinsValue += 2;
            }
            else if(greenCoin)
            {
                coinsValue += 4;
            }
            int value = PlayerPrefs.GetInt("Coins");
            value += coinsValue;
            PlayerPrefs.SetInt("Coins", value);
            Destroy(this.gameObject);
        }
    }
}
