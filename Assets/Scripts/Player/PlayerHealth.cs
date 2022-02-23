using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("PlayerHealth")]
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set;}
    private Animator animator;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            animator.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
        }else{
            if(!dead)
            {
                animator.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;

            }
            

        }
        
        
    }
    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7, true);
        for (int i=0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f);  //setting red flashing color while invulnerability is active
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes *2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes *2));
        }
        Physics2D.IgnoreLayerCollision(6,7, false);

    }
}
