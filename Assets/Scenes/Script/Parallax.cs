using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float offset;
    private Vector2 startPosition;
    private float newXPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    
    void Update()
    {
        newXPosition = Mathf.Repeat(Time.time * -moveSpeed, offset);
        transform.position = startPosition + Vector2.right * newXPosition;
    }
}
