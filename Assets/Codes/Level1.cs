using UnityEngine;
using System.Collections.Generic;

public class Level1 : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject[] itemPrefabs;
    public float Lines;
    public float Distance;
    public float ScreenBoundsX;
    public FlowDirection flowDirection;
    public float platformSpeed;

    private float spawnTime;
    private List<GameObject> platformPool = new List<GameObject>();
    private List<GameObject> itemPool = new List<GameObject>();

    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + Distance;
            SpawnPlatforms();
        }

        CheckAndDeactivatePlatforms();
        CheckAndDeactivateItems();
    }
 public enum FlowDirection
    {
        Right, Left
    }
void SpawnPlatforms()
{
    GameObject platformPrefab = GetPlatformFromPool();
    GameObject itemPrefab = GetItemFromPool();

    float spawnX = (flowDirection == FlowDirection.Right) ? -4f : 4f;
    float vanishX = (flowDirection == FlowDirection.Right) ? 8f : -8f;
    float speed = (flowDirection == FlowDirection.Right) ? platformSpeed : -platformSpeed;

    Vector3 spawnPosition = transform.position + new Vector3(spawnX, Lines, 0);//Code Review
    
    if (platformPrefab != null)
    {
        platformPrefab.transform.position = spawnPosition;

        // Встановлюємо швидкість руху після встановлення позиції
        Platforms platformScript = platformPrefab.GetComponent<Platforms>();
        if (platformScript != null)
        {
            platformScript.SetMoveSpeed(speed, vanishX);
            platformScript.enabled = true;
        }

        // Активуємо платформу після встановлення всіх параметрів
        platformPrefab.SetActive(true);
    }

    if (itemPrefab != null)
    {
        itemPrefab.transform.position = spawnPosition;

        // Встановлюємо швидкість руху після встановлення позиції
        Items itemScript = itemPrefab.GetComponent<Items>();
        if (itemScript != null)
        {
            itemScript.SetMoveSpeed(speed, vanishX);
            itemScript.enabled = true;
        }

        // Активуємо itemPrefab після встановлення всіх параметрів
        itemPrefab.SetActive(true);
    }
    platformSpeed = PlayerPrefs.GetFloat("Line Speed", platformSpeed);
    Distance = PlayerPrefs.GetFloat("Line Distance", Distance);


    // Додайте виклик Update для платформи
    platformPrefab.GetComponent<Platforms>().enabled = true;
}


    GameObject GetPlatformFromPool()
    {
        foreach (GameObject platform in platformPool)
        {
            if (!platform.activeInHierarchy)
            {
                GameObject newPlatformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
                platform.GetComponent<SpriteRenderer>().sprite = newPlatformPrefab.GetComponent<SpriteRenderer>().sprite;
                return platform;
            }
        }

        GameObject newPlatform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)]);
        newPlatform.SetActive(false);
        platformPool.Add(newPlatform);

        return newPlatform;
    }

    GameObject GetItemFromPool()
    {
        foreach (GameObject item in itemPool)
        {
            if (!item.activeInHierarchy)
            {
                GameObject newItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                item.GetComponent<SpriteRenderer>().sprite = newItemPrefab.GetComponent<SpriteRenderer>().sprite;
                return item;
            }
        }

        GameObject newItem = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
        newItem.SetActive(false);
        itemPool.Add(newItem);

        return newItem;
    }

    void CheckAndDeactivatePlatforms()
    {
        float screenLeftBound = ScreenBoundsX;

        foreach (GameObject platform in platformPool)
        {
            if (platform.activeInHierarchy && platform.transform.position.x < screenLeftBound)
            {
                platform.SetActive(false);
            }
        }
    }

    void CheckAndDeactivateItems()
    {
        float screenLeftBound = -8;

        foreach (GameObject item in itemPool)
        {
            if (item.activeInHierarchy && item.transform.position.x < screenLeftBound)
            {
                item.SetActive(false);
            }
        }
    }
}
