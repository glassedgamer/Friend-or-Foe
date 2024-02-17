using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

    GameObject levelChanger;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject howToPlay;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");

        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void Play() {
        levelChanger.GetComponent<LevelChanger>().LoadFirstLevel();
    }

    public void HowToPlay() {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void Back() {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

}
