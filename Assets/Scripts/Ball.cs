using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle; //now this can be private because we used FindObjectOfType, and don't need to link the objects in Unity
    private Ball ball;
    private Vector3 paddleToBallVector;
    public bool isLaunched = false;
    
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>(); //chevron = generics? *kind of like a filter
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }
	
	void Update () {
        if (isLaunched != true){
            // Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for a mouse press to launch.
            if (Input.GetMouseButtonDown(0)){
                isLaunched = true;
                
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), 8f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (isLaunched == true)
        {
            GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
    
}
