using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour {

    GameObject levelChanger;

    void Start() {
        levelChanger = GameObject.FindWithTag("LevelChanger");
    }

    public void Retry() {
        levelChanger.GetComponent<LevelChanger>().LoadFirstLevel();
    }

    public void MainMenu() {
        levelChanger.GetComponent<LevelChanger>().LoadMainMenu();
    }

}
