using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public float gravity;
    public float flapRange;
    public float gravityRange;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.birdAlive = true;
        logic.gameMoveSpeed = 5;
        myRigidBody.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        //Press space to go up
        if (Input.GetKeyDown(KeyCode.Space) && logic.birdAlive)
        {
            FindObjectOfType<AudioManagerScript>().Play("Jump");
            myRigidBody.velocity = Vector2.up * Random.Range(flapStrength - flapRange, flapStrength + flapRange);
            myRigidBody.gravityScale = Random.Range(gravity - gravityRange, gravity + gravityRange);
        }
    }

    //Game Over Trigger
    private void OnCollisionEnter2D(Collision2D collision){
        if (logic.birdAlive == true){
            FindObjectOfType<AudioManagerScript>().Play("Dead");
            logic.gameOver();
        }
        logic.birdAlive = false;
    }
}
