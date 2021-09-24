using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObjSpawn : MonoBehaviour
{
    public GameObject objSpawnPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ObjWave());
    }

    private void SpawObj()
    {
        GameObject a = Instantiate(objSpawnPrefab) as GameObject;
        a.transform.position = new Vector2(-screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
    }

    IEnumerator ObjWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawObj();
        }
        
    }
    void Update()
    {
        
    }
}
