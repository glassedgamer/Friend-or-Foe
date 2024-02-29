using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {

    GameObject levelChanger;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject howToPlay;

    AudioSource lobbyMusic;

    void Awake() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
        lobbyMusic = GameObject.FindWithTag("LobbyMusic").GetComponent<AudioSource>();

        lobbyMusic.enabled = true;

        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void Play() {
        FindObjectOfType<AudioManager>().Play("Click");

        lobbyMusic.enabled = false;

        levelChanger.GetComponent<LevelChanger>().LoadFirstLevel();
    }

    public void HowToPlay() {
        FindObjectOfType<AudioManager>().Play("Click");
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void Back() {
        FindObjectOfType<AudioManager>().Play("Click");
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

}
