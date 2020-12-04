using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float spawnRate = 1f;        // Time in seconds between spawn
    public float spawnIncreasePercentage = 10f;     // Spawn rate increase % per interval
    public float spawnIncreaseInterval = 10f;       // Interval to increase spawn rate
    public Camera mainCamera;

    private float enemySpawnDistance;
    private float enemySpawnDistancePadding = 2f;
    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(RampSpawnRate());
    }

    void FixedUpdate()
    {
        if (canSpawn)
        {
            SpawnEnemy();
            StartCoroutine(SpawnLockout());
        }
    }

    void SpawnEnemy()
    {
        //Debug.Log("spawn enemy");
        CalculateSpawnDistance();
        float angle = Random.Range(0, 360);
        GameObject newEnemy = Instantiate(enemy, GetSpawnVector(mainCamera.transform.position, angle), Quaternion.identity);
        newEnemy.GetComponent<EnemyMovement>().player = this.player;
    }

    IEnumerator SpawnLockout()
    {
        canSpawn = false;
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
    }

    Vector3 GetSpawnVector(Vector3 camVector, float angle)
    {
        return new Vector3(camVector.x + Mathf.Sin(angle), camVector.y + Mathf.Cos(angle), 0) * enemySpawnDistance;
    }
    void CalculateSpawnDistance()
    {
        // Calculate the distance between camera center to a corner
        Vector2 vectorToCorner = new Vector2(mainCamera.orthographicSize, mainCamera.orthographicSize * mainCamera.aspect);
        enemySpawnDistance = vectorToCorner.magnitude + enemySpawnDistancePadding;
    }

    // Increase spawn rate over time
    IEnumerator RampSpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnIncreaseInterval);
            spawnRate *= 100 / (100 + spawnIncreasePercentage);
            //Debug.Log("spawn interval = " + spawnRate);
        }
    }
}
