using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    //weapon for the tower, and what will follow the enemy, edited in the unity inspector
    [SerializeField] Transform weapon;
    //what the tower is targeting
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //this will assign the target to the tower prefab when game is launched
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        //this is responsible for the weapon, which was assigned in the inspector, to follow the enemy
        weapon.LookAt(target);
    }
}
