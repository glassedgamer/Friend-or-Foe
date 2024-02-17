using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] Text timerText;
    [SerializeField] Text pointsText;
    [SerializeField] Text livesText;

    bool gameNotOver = true;

    float timerValue = 5;

    int points = 0;
    [SerializeField] int lives = 3;

    string playerInput;
    string person;

    WaitForSeconds countDownTimerInterval;

    void Start() {
        lives = 3;

        timerText.text = points + " Points";
        livesText.text = lives + " Lives";

        NewPersonAtDoor();
        TimeToAnswer();
    }

    void Update() {
        if(lives <= 0) {
            GameOver();
        }

        TimeToAnswer();
    }

    // Function that runs when friend button is pressed
    public void FriendButton() {
        // Sets player input to friend and prints it
        playerInput = "Friend";
        print(playerInput);

        /* 
            If player input is equal to person, reset and add a point
            If the two are not equal, run the game over function
        */

        if(playerInput == person) {
            points++;
            pointsText.text = points + " Points";

            playerInput = "Nothing";
            NewPersonAtDoor();
        } else if(playerInput != person) {
            // Takes away a live
            lives--;
            livesText.text = lives + " Lives";

            timerValue = 5;

            NewPersonAtDoor();
        } 
    }

    // Function that runs when foe button is pressed
    public void FoeButton() {
        // Sets player input to foe and prints it
        playerInput = "Foe";
        print(playerInput);

        /* 
            If player input is equal to person, reset and add a point
            If the two are not equal, run the game over function
        */
        if(playerInput == person) {
            points++;
            pointsText.text = points + " Points";

            playerInput = "Nothing";
            NewPersonAtDoor();
        } else if(playerInput != person) {
            // Takes away a live
            lives--;
            livesText.text = lives + " Lives";

            timerValue = 5;

            NewPersonAtDoor();
        } 
    }


    // Randomally sets a new person to hide behind door while starting 30 second timer
    void NewPersonAtDoor() {
        timerValue = 5;

        var randomInt = Random.Range(1, 3);

        if(randomInt == 1) {
            person = "Friend";
        } else if(randomInt == 2) {
            person = "Foe";
        }

        // TimeToAnswer();
    }

    void GameOver() {
        gameNotOver = false;

        print("GAME OVER NOOB");
    }

    // Timer function
    void TimeToAnswer() {
        if(gameNotOver) {
            timerValue -= Time.deltaTime;

            timerText.text = timerValue.ToString("0") + " seconds left";

            if (timerValue <= 0) {
                GameOver();
            }
        } 
    }
    
}
