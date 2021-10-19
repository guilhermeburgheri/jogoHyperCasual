using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorarColisao : MonoBehaviour
{
    private BoxCollider2D objCollider;
    private BoxCollider2D canoCollider;
    private BoxCollider2D canoCollider2;
    private BoxCollider2D chao;
    private BoxCollider2D chao1;

    void Start()
    {
        objCollider = GetComponent<BoxCollider2D>();
        canoCollider = GameObject.Find("CanoManobra").GetComponent<BoxCollider2D>();
        canoCollider2 = GameObject.Find("CanoManobra2").GetComponent<BoxCollider2D>();
        chao = GameObject.Find("Chao").GetComponent<BoxCollider2D>();
        chao1 = GameObject.Find("Chao (1)").GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(objCollider, canoCollider, true);
        Physics2D.IgnoreCollision(objCollider, canoCollider2, true);
        Physics2D.IgnoreCollision(objCollider, chao, true);
        Physics2D.IgnoreCollision(objCollider, chao1, true);
    }
}
