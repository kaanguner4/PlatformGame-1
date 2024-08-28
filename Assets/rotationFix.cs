using UnityEngine;

public class CanvasFollower : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        this.gameObject.transform.position = new Vector2(player.transform.position.x +0.1f, player.transform.position.y + 0.4f);
    }
}
