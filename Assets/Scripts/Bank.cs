using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    //hiw much the player will start having
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance = 150;

    //how much money the player currently has
    public int CurrentBalance
    {
        get { return currentBalance; }
    }

    void Awake()
    {
        //this will make the players balance to the starting balance which is 150
        currentBalance = startingBalance;
    }

    //this will add money into the players account
    public void Deposit(int amount)
    {
        //Mathf.abs will convert negative numbers into positive just incase if player deposits a negative value
        currentBalance += Mathf.Abs(amount);
    }

    //this will subtract the money in the players account
    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        if (currentBalance < 0)
        {
            //lose the game
            ReloadScene();
        }
    }

    //this will restart the game
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
