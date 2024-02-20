using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

    GameObject levelChanger;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject howToPlay;

    AudioSource lobbyMusic;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
        lobbyMusic = GameObject.FindWithTag("LobbyMusic").GetComponent<AudioSource>();

        lobbyMusic.enabled = true;

        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void Play() {
        lobbyMusic.enabled = false;

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
