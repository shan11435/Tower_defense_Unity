using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when you drag this script into unity inspector, it will also automatically add the enemy script file (this file depends on enemy script file)
[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    
    //adding health to enemy after death
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] int currentHitPoints = 0;

    //start the process of calling the enemy c# script file
    Enemy enemy;
    //start the process of calling the enemy mover C# script file
    EnemyMover enemyMover;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        //this is used instead findobjectoftype is because this script and the enemy script are inside the enemy object
        enemy = GetComponent<Enemy>();
        //this is used instead findobjectoftype is because this script and the enemy script are inside the enemy object
        enemyMover = GetComponent<EnemyMover>();
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
            //this will increase the enemy health to 1 everytime it dies
            maxHitPoints += difficultyRamp;
            //will add gold into players account, it's blank because in enemy script it's adding 25 gold
            enemy.RewardGold();
            //this will increase the enemy object speed everytime it dies
            enemyMover.IncreaseSpeed(0.01f);
        }
    }
}
