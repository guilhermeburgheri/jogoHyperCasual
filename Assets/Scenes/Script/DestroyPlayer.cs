using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject gameStateObject;
    GameState gameStateScript;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy" && this.transform.position.x < other.transform.position.x)
        {
            Destroy(gameObject);
            gameStateObject = GameObject.Find("StateMachine");
            gameStateScript = gameStateObject.GetComponent<GameState>();
            if(gameStateScript)
            {
                gameStateScript.EndGame();
            }
        }
    }
}
