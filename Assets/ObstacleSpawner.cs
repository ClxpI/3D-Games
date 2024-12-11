using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject cubeObstaclePrefab;
    public GameObject capsuleObstaclePrefab;
    public Transform player;
    public ScoreManager scoreManager;
    public float spawnInterval = 0.0001f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnTwoObstacles();
            timer = 0;
        }
    }

    void SpawnTwoObstacles()
    {
        float planeWidth = 4.8f;  // Adjusted for safe spawn range within Plane
        float spawnZPosition = player.position.z + 12f;
        float margin = 0.2f;  // Safe margin from Plane edges

        GameObject obstacle1 = Random.Range(0f, 1f) > 0.5f ? cubeObstaclePrefab : capsuleObstaclePrefab;
        GameObject obstacle2 = Random.Range(0f, 1f) > 0.5f ? cubeObstaclePrefab : capsuleObstaclePrefab;

        Vector3 spawnPos1 = new Vector3(
            Random.Range(-planeWidth + margin, planeWidth - margin),
            0.5f,
            spawnZPosition
        );

        Vector3 spawnPos2;
        do
        {
            spawnPos2 = new Vector3(
                Random.Range(-planeWidth + margin, planeWidth - margin),
                0.5f,
                spawnZPosition
            );
        }
        while (Vector3.Distance(spawnPos1, spawnPos2) < 1.5f);

        Instantiate(obstacle1, spawnPos1, Quaternion.identity);
        Instantiate(obstacle2, spawnPos2, Quaternion.identity);

        if (scoreManager != null)
        {
            scoreManager.IncreaseScore();
        }
    }

}
