using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] Text timerText;
    [SerializeField] Text pointsText;
    [SerializeField] Text livesText;
    [SerializeField] Text countdownText;

    WaitForSeconds introTimeBetween;

    GameObject levelChanger;

    AudioSource lobbyMusic;

    bool gameNotOver = false;

    float timerValue = 5;

    public static int points = 0;
    [SerializeField] int lives = 3;

    string playerInput;
    string person;

    WaitForSeconds countDownTimerInterval;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
        lobbyMusic = GameObject.FindWithTag("LobbyMusic").GetComponent<AudioSource>();

        lobbyMusic.enabled = true;

        lives = 3;
        introTimeBetween = new WaitForSeconds(1f);

        timerText.text = points + " Points";
        livesText.text = lives + " Lives";

        StartCoroutine(IntroTimer());

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
        lobbyMusic.enabled = false;

        print("GAME OVER NOOB");

        levelChanger.GetComponent<LevelChanger>().LoadGameOver();
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

    IEnumerator IntroTimer() {
        for (int i = 3; i >= 0; i--) {
            countdownText.text = i.ToString();

            if (i == 0) {
                gameNotOver = true;

                countdownText.text = "GO";
                yield return introTimeBetween;
                countdownText.gameObject.SetActive(false);
            }

            yield return introTimeBetween;

        }
    }
    
}
