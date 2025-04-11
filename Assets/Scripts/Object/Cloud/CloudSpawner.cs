using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnTimeMin = 2f;
    public float spawnTimeMax = 5f;
    float nextTime;

    public float position_X = -800f;
    public float position_Z = 0f;
    public float randomYMin = 350f;
    public float randomYMax = 400f;
    float randomY;

    void Start()
    {
        SpawnCloud();
    }

    void SpawnCloud()
    {
        randomY = Random.Range(randomYMin, randomYMax);
        Vector3 spawnLoc = new Vector3(position_X, randomY, position_Z);
        Instantiate(cloudPrefab, spawnLoc, Quaternion.identity);

        nextTime = Random.Range(spawnTimeMin, spawnTimeMax);
        Invoke("SpawnCloud", nextTime);
    }
}
