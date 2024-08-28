using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] public int healthValue;
    public Health Health;
    private void OnTriggerEnter2D(Collider2D collision)
    {   
       
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
        
            
    }
}