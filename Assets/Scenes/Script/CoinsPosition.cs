using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPosition : MonoBehaviour
{
    private Vector2 screensBounds;
    // Start is called before the first frame update
    void Start()
    {
        screensBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        transform.position = new Vector2(0, Random.Range(screensBounds.y/2, screensBounds.y/4));
    }

}
