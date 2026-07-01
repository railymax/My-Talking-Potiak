using UnityEngine;

public class Catching : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform player;
    public float minX = -8f;
    public float maxX = 8f;

    [Header("Spawner Settings")]
    public GameObject[] items;
    public float spawnRate = 1f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, spawnRate);
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (player == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float clampedX = Mathf.Clamp(mousePos.x, minX, maxX);
        player.position = new Vector3(clampedX, player.position.y, 0);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnpos = new Vector3(randomX, transform.position.y, 0);

        int chance = Random.Range(1, 101);
        int index = (chance == 1) ? 2 : (chance <= 50 ? 0 : 1);

        Instantiate(items[index], spawnpos, Quaternion.identity);
    }
}
