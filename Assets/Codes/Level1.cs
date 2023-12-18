using UnityEngine;

public class SpawnLines : MonoBehaviour
{
    public GameObject[] platformPrefabs; // Array of platform prefabs (one for each type and size)
    public GameObject[] items;
    public float Lines;
    public float Spawn;
    public float Distance;
    private float spawnTime;
    public float X_Move;
    //public Transform Line2;
    void Update()
    {
        if(Time.time > spawnTime)
        {
            PlayerPrefs.SetFloat("Speed", X_Move);
            spawnTime = Time.time + Distance;
            SpawnPlatforms();
        }
    }

    void SpawnPlatforms()
    {
        GameObject LogPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
        GameObject ItemPrefab = items[Random.Range(0, items.Length)];
        Instantiate(LogPrefab, transform.position + new Vector3(Spawn, Lines, 0), transform.rotation);
        Instantiate(ItemPrefab, transform.position + new Vector3(Spawn, Lines, 0), transform.rotation);
    }
}
