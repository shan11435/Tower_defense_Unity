using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //what enemy is spawning
    [SerializeField] GameObject enemyPrefab;
    //how many enemies will spawn
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    //how long an enemy will spawn
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    //this will store the number of spawned enemies
    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        //this will start the spawnenemy method automatically
        StartCoroutine(SpawnEnemy());
    }

    //this will make the enemies spawn
    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    //this will cause the enemies to infinitely spawn
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnabledObjectInPool();
            //this will spawn the enemy every 1 second, based on the spawntimer variable
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    //this will activate the game object if disabled 
    void EnabledObjectInPool()
    {
        //loooping through the enemy gameobject array
        for (int i = 0; i < pool.Length; i++)
        {
            //if the object is disabled in unity inspector
            if (pool[i].activeInHierarchy == false)
            {
                //activate the gameobject
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
