using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    public float flapStrength = 20;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float verticalLimit = 15;
    private bool isJumping=false;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive) {
            myRigidbody2D.velocity = Vector2.up * flapStrength;
            isJumping = true;
        }

        float verticalPosition = transform.position.y;
        if (verticalPosition > verticalLimit || verticalPosition < -verticalLimit) {
            die();
        }

        animate();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        die();
    }

    private void die() {
        birdIsAlive = false;
        logic.gameOver();
    }

    private void animate() {
        if (isJumping) {
            myAnimator.SetTrigger("Jump");
            isJumping = false;
        }
    }
}
