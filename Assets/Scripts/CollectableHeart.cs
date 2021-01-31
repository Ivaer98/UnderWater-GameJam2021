using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHeart : MonoBehaviour
{
    [SerializeField] int timeToDestroy = 10;
    [SerializeField] int healthToRestore = 150;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPlaneMovement playerPlane = FindObjectOfType<PlayerPlaneMovement>();
            playerPlane.health += healthToRestore;
            if (playerPlane.health > playerPlane.maxHealth)
            {
            playerPlane.health = playerPlane.maxHealth;

            }
            
            Destroy(gameObject);
        }

    }*/
}
