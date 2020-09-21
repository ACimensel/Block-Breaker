using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Sprite[] hitSprites;
    public GameObject smoke;
    public static int breakableBrickCount = 0;
    
    private int timesHit;
    private bool isBreakable;
    
    void Start()
    {
        isBreakable = (this.tag == "Breakable"); //have to initialize at start and not at top because brick isn't in existence yet
        if (isBreakable)
        {
            breakableBrickCount += 1;
        }
    }
    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            breakableBrickCount--;
            PuffSmoke();
            Destroy(gameObject);
            if (breakableBrickCount == 0) {
                LevelManagerScript.LoadNextLevel();
            }
        } else {
            LoadSprites();
        }
    }

    void PuffSmoke() {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null) { //if sprite is missing, keep old sprite so brick doesn't stay invisible
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; /*takes you to Sprite Renderer under Inspector, then to Sprite. Sets equal of Hit Sprites [index]*/
        } else {
            Debug.LogError("Brick sprite missing");
        }
    }
    
}


