using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    [SerializeField] private float push;
    private GameObject player;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                rigidbody2.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                //transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                rigidbody2.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                //transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Vector2 forceDirection = (collision.transform.position - transform.position).normalized;
            player.GetComponent<Rigidbody2D>().AddForce(forceDirection * push, ForceMode2D.Force);
        }
    }
}