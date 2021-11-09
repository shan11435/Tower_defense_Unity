using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    //hiw much the player will start having
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance = 150;
    //this will make it possible to edit the text UI
    [SerializeField] TextMeshProUGUI displayBalance;
    
    //how much money the player currently has
    public int CurrentBalance
    {
        get { return currentBalance; }
    }

    void Awake()
    {
        //this will make the players balance to the starting balance which is 150
        currentBalance = startingBalance;
        //change the text UI
        UpdateDisplay();
    }

    //this will add money into the players account
    public void Deposit(int amount)
    {
        //Mathf.abs will convert negative numbers into positive just incase if player deposits a negative value
        currentBalance += Mathf.Abs(amount);
        //change the text UI
        UpdateDisplay();
    }

    //this will subtract the money in the players account
    public void Withdrawal(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        //change the text UI
        UpdateDisplay();
        if (currentBalance < 0)
        {
            //lose the game
            ReloadScene();
        }
    }

    //this will change the text based on the current balance
    void UpdateDisplay()
    {
        //this will cause the player to see how much gold he has
        displayBalance.text = "Gold: " + currentBalance;
    }

    //this will restart the game
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
