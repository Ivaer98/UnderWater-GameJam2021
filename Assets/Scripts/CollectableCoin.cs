using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{
    [SerializeField] int timeToDestroy = 6;
    [SerializeField] int scoreToAdd = 1000;
    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject, timeToDestroy);        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
        ScoreBoard scoreBoard = FindObjectOfType<ScoreBoard>();
        scoreBoard.AddScore(scoreToAdd);
        Destroy(gameObject);
        }
        
    }
}
