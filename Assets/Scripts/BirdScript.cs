using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float flapStrength = 20;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float verticalLimit = 13;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            myRigidbody2D.velocity = Vector2.up * flapStrength;
        }

        float verticalPosition = transform.position.y;
        if (verticalPosition > verticalLimit || verticalPosition < -verticalLimit) {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        die();
    }

    private void die() {
        birdIsAlive = false;
        logic.gameOver();
    }
}
