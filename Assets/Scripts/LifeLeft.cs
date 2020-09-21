using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeLeft : MonoBehaviour {

    public Sprite[] lifeSprites;
    public static int livesLeft = 3;
    static LifeLeft instance = null;

    void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadSprites() {
        if (livesLeft == 3) {
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[livesLeft];
        } if (livesLeft == 2) {
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[livesLeft];
        } if (livesLeft == 1) {
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[livesLeft];
        } if (livesLeft == 0) {
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[livesLeft];
        }
    }

    public void NewGame() {
        if (livesLeft == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = lifeSprites[livesLeft];
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
