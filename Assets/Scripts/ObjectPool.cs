using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //this will start the spawnenemy method
        StartCoroutine(SpawnEnemy());
    }

    //this will cause the enemies to infinitely spawn
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //this will spawn the enemy
            Instantiate(enemyPrefab, transform);
            //this will spawn the enemy every 1 second, based on the spawntimer variable
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
