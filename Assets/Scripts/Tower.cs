using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //cost to build the tower
    [SerializeField] int cost = 75;
    
    //this is responsible for creating the tower
    public bool CreateTower(Tower tower, Vector3 position)
    {
        //this will find the bank class in our unity project
        Bank bank = FindObjectOfType<Bank>();
        //if player has no money
        if (bank == null)
        {
            return false;
        }

        //if player has enough money to pay for the tower
        if (bank.CurrentBalance >= cost)
        {
            //this will spawn the tower when clicking on a tile
            Instantiate(tower.gameObject, position, Quaternion.identity);
            //take out the money out of the players account
            bank.Withdrawal(cost);
            return true;
        }

        //if all else fails
        return false;
    }
}
