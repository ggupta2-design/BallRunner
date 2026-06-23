using UnityEngine;

// This script spawns obstacles from the right side of the screen
public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public GameObject obstaclePrefab;     // The obstacle to spawn
    public float minSpawnTime = 1.5f;     // Fastest spawn rate
    public float maxSpawnTime = 3.0f;     // Slowest spawn rate
    public float spawnX = 10f;            // How far right obstacles start
    public float spawnY = -2.5f;          // Y position (ground level)

    private float timer;
    private bool isRunning = false;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObstacle();
            ResetTimer();
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }

    void ResetTimer()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Called by GameManager to start/stop spawning
    public void StartSpawning() { isRunning = true; }
    public void StopSpawning()  { isRunning = false; }
}
