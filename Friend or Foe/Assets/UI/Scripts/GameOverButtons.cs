using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverButtons : MonoBehaviour {

    GameObject levelChanger;

    [SerializeField] Text pointsText;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");

        pointsText.text = "Points: " + GameManager.points.ToString();
    }

    public void Retry() {
        FindObjectOfType<AudioManager>().Play("Click");

        GameManager.points = 0;

        levelChanger.GetComponent<LevelChanger>().LoadFirstLevel();
    }

    public void MainMenu() {
        FindObjectOfType<AudioManager>().Play("Click");

        GameManager.points = 0;

        levelChanger.GetComponent<LevelChanger>().LoadMainMenu();
    }

}
