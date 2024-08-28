using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class Firetrap : MonoBehaviour
{
    [SerializeField] private int damage;
    [Header("FireTrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator animator;
    private SpriteRenderer spriteRender;

    private bool triggered;
    private bool active;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivateFireTrap()
    {
        triggered = true;
        spriteRender.color = Color.red;
        
        yield return new WaitForSeconds(activationDelay);
        spriteRender.color = Color.white;
        active = true;
        animator.SetBool("activated", true); 
        
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        animator.SetBool("activated", false);

    }
}
