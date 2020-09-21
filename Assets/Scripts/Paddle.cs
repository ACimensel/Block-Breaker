using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>(); //chevron = generics? *kind of like a filter
    }

    // Update is called once per frame
    void Update () {
        if (autoPlay == false) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
    }

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(6f, this.transform.position.y, this.transform.position.z);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 1f, 15f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse() {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; //relative mouse position between 0 and 1 x16 (position in game blocks)
        Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, .8f, 15.2f), this.transform.position.y, this.transform.position.z);

        this.transform.position = paddlePos; //'this' refers to current object (Paddle)
        //instance of current script, Paddle (Script). 'Destroy this' destroys Paddle (Script) against Paddle Object
        //don't need 'this' in this case and would work with transform.position
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float ballVelocity = ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        
        float ballXpos = ball.transform.position.x;
        float paddleXpos = this.transform.position.x;
        float powerAdjustor = (ballXpos - paddleXpos)*8;

        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(powerAdjustor, Mathf.Sqrt(ballVelocity*ballVelocity - powerAdjustor*powerAdjustor));
    }

}
