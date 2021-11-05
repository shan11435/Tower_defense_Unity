using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    //weapon for the tower, and what will follow the enemy, edited in the unity inspector
    [SerializeField] Transform weapon;
    [SerializeField] private ParticleSystem projectileParticles;
    //this will determine the distance a tower needs to be close with the enemy until he can fire 
    [SerializeField] private float range = 15f;
    //what the tower is targeting
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        //determines whether the enemy is in range of the tower so the tower can attack the enemy
        float targetDistance = Vector3.Distance(transform.position, target.position);
        //this is responsible for the weapon, which was assigned in the inspector, to follow the enemy
        weapon.LookAt(target);
        //if the enemy is close enough to the tower
        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }
    
    //this will allow the particles to come out of the tower
    void Attack(bool isActive)
    {
        //this will enable the feature that makes particles appear
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
