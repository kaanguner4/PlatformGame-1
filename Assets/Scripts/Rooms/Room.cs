using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] traps;
    private Vector3[] initialPosition;
    private Vector3[] initialPositionTraps;


    private void Awake()
    {
        // Save the initial positions of the enemies
        initialPosition = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                initialPosition[i] = enemies[i].transform.position;
        }
        // traps
        initialPositionTraps = new Vector3[traps.Length];
        for (int i = 0; i < traps.Length; i++)
        {
            if (traps[i] != null)
                initialPositionTraps[i] = traps[i].transform.position;
        }
    }
    public void ActivateRoom(bool roomEntry)
    {
        // Activate/deactivate enemies and traps

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(false);
                enemies[i].transform.position = initialPosition[i];
            }
        }
        for (int i = 0; i < traps.Length; i++)
        {
            if (traps[i] != null)
            {
                traps[i].SetActive(roomEntry);
                traps[i].transform.position = initialPositionTraps[i];
            }
        }
    }
}
