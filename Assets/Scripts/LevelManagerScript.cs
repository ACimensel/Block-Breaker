using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // had to bring this in to use SceneManager. LoadScene below

public class LevelManagerScript : MonoBehaviour {

    private LifeLeft lifeLeft;

    public void LoadLevel(string name)
    {
        lifeLeft = GameObject.FindObjectOfType<LifeLeft>();
        LifeLeft.livesLeft = 3;
        Brick.breakableBrickCount = 0;

        Debug.Log("Level load requested: " + name);
        SceneManager.LoadScene(name);
        lifeLeft.LoadSprites();
    }

    public void QuitRequest() {
        Debug.Log("Quit game requested");
        Application.Quit(); // no effect in web build/plugin and in-editor builds. Works great on PC/console/mobile builds
    }

    public static void LoadNextLevel() { //what is static??? Why did it make it work??????
        Brick.breakableBrickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }










}
