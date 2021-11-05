using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variable for how much the enemy will drop when dead
    [SerializeField] int goldReward = 25;
    //variable for how mich gold the enemy takes if it reaches the end of the path
    [SerializeField] int goldPenalty = 25;

    //start the process of calling the bank c# script file
    Bank bank;
    
    // Start is called before the first frame update
    void Start()
    {
        //this will find the class bank in our unity project
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        //if there's no money in account return nothing
        if (bank == null)
        {
            return;
        }
        //will add money into players account
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        //if there's no money in account return nothing
        if (bank == null)
        {
            return;
        }
        //will subtract money in players account
        bank.Withdrawal(goldPenalty);
    }

}
