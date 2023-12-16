using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject[] platformPrefabs; // Array of platform prefabs (one for each type and size)
    public float[] Lines;
    public float Distance;
    private float spawnTime;
    //public Transform Line2;
    void Update()
    {
        if(Time.time > spawnTime)
        {
            spawnTime = Time.time + Distance;
            SpawnPlatforms();
        }
    }

    void SpawnPlatforms()
    {
        GameObject LogPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
        Instantiate(LogPrefab, transform.position + new Vector3(3, Lines[0], 0), transform.rotation);
        Instantiate(LogPrefab, transform.position + new Vector3(3, Lines[1], 0), transform.rotation);
    }
}
