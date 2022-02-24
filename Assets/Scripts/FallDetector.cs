using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public PlayerHealth playerhealth;
    //public GameOverScreen gameover;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // gameover.Setup();
            playerhealth.TakeDamage(playerhealth.currentHealth);
            
        }
    }
}
