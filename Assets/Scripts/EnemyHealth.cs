using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    //start the process of calling the bank c# script file
    Enemy enemy;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        //this is used instead findobjectoftype is because this script and the enemy script are inside the enemy object
        enemy = GetComponent<Enemy>();
    }

    //in unity, on the particle system under collision, you have to check send collision messages
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            //this will disbable the enemy gameobject to be reused again in the future
            gameObject.SetActive(false);
            //will add gold into players account, it's blank because in enemy script it's adding 25 gold
            enemy.RewardGold();
        }
    }
}
