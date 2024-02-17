using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelChanger : MonoBehaviour {

    public Animator anim;

    public float transitionTime = 2f;

    WaitForSeconds timeBetweenLevel;

    void Start() {
        timeBetweenLevel = new WaitForSeconds(transitionTime);
    }

    public void LoadFirstLevel() {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadLevel(2));
    }

    public IEnumerator LoadLevel(int levelIndex) {
        anim.SetTrigger("Start");

        yield return timeBetweenLevel;

        SceneManager.LoadScene(levelIndex);
    }

}
