using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controle : MonoBehaviour
{
    public void ProximaCena(string id)
    {

        SceneManager.LoadScene(id);
    }
}
