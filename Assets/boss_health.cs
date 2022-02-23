using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    public int health = 500;
    public GameObject deathEffect;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }
        if(health<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
