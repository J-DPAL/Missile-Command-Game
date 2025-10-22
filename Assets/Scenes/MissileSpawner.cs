using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 3f;
    public float minSpawnInterval = 1.5f;

    [Header("Difficulty Settings")]
    public float missileSpeed = 2.5f;
    public int missilesPerLevel = 10;
    public float missileSpeedIncrement = 0.5f;

    private int missileCount = 0;
    private int level = 1;
    private float spawnTimer = 0f;

    void Start()
    {
        if (missilePrefab == null)
        {
            missilePrefab = Resources.Load<GameObject>("Missile");
            if (missilePrefab == null)
            {
                Debug.LogError("Missile prefab not found in Resources folder!");
                return;
            }
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnMissile();
            spawnTimer = 0f;
        }
    }

    void SpawnMissile()
    {
        float xPos = Random.Range(-8f, 8f);
        Vector3 spawnPos = new Vector3(xPos, 6f, 0);

        GameObject missile = Instantiate(missilePrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();

        Vector2 rawDir = new Vector2(Random.Range(-1f, 1f), -1f);
        Vector2 diagDir = rawDir.normalized;

        float angle = Mathf.Atan2(diagDir.y, diagDir.x) * Mathf.Rad2Deg;
        missile.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        rb.linearVelocity = diagDir * missileSpeed;

        missileCount++;
        Debug.Log($"[{gameObject.name}] Missile Count: {missileCount}");


        if (missileCount % missilesPerLevel == 0)
        {
            level++;
            missileSpeed += missileSpeedIncrement;
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - 0.2f);
            Debug.Log("Level Up! Now at Level: " + level);
        }
    }

    public int GetLevel() => level;
}
