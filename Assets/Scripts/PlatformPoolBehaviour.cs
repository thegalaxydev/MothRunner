using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlatformPoolBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject platformPreFab;

    [SerializeField] private float currentXSpawnPosition = 5f;

    [SerializeField] private bool collectionChecks = true;

    [SerializeField] private int maxPoolSize = 15;

    public IObjectPool<GameObject> Pool { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Pool = new ObjectPool<GameObject>(CreatePlatform, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
    }

    public void SpawnPlatform()
    {
        Pool.Get();
    }

    public void ReleasePlatform(GameObject platform)
    {
        Pool.Release(platform);
    }

    private GameObject CreatePlatform()
    {
        //Creates a new platofrm within parent transform
        GameObject platform = Instantiate(platformPreFab, transform);
        platform.SetActive(false);

        return platform;
    }

    //Called when a platform is taken from the pool using Get()
    private void OnTakeFromPool(GameObject platform)
    {
        //Moves the platform to the currentXSpawnPosition
        platform.transform.position = new Vector3(currentXSpawnPosition, 0, 0);

        //Set Platform's Active to true
        platform.gameObject.SetActive(true);
    }

    //Called when a platform is returned to the pool 
    private void OnReturnedToPool(GameObject platform)
    {
        platform.gameObject.SetActive(false);
    }

    //If the pool capacity is reached then any platforms returned will be destroyed
    //This function destroys the GameObject
    private void OnDestroyPoolObject(GameObject platform)
    {
        Destroy(platform);
    }
}
