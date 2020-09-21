using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private Ball ball;
    private Paddle paddle;
    private LifeLeft lifeLeft;
    private Vector3 paddleToBallVector;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        lifeLeft = GameObject.FindObjectOfType<LifeLeft>();
        paddleToBallVector = ball.transform.position - paddle.transform.position;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        LifeLeft.livesLeft--;
        lifeLeft.LoadSprites();

        if (LifeLeft.livesLeft <= 0) {
            SceneManager.LoadScene("Lose Screen");
        } else {
            ball.isLaunched = false;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            ball.transform.position = paddle.transform.position + paddleToBallVector;
        }
    }
    
}
