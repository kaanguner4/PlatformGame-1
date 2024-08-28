using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] public HealthBar healthBar;
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int _damage)
    {
        currentHealth -=_damage;
        healthBar.SetHealth (currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                //GetComponent<HealthBar>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(int _value)
    {
        if (currentHealth != maxHealth)
        {
            currentHealth += _value;
            healthBar.SetHealth(currentHealth);
        }
    }   

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10,11,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}