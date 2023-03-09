using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZippyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.birdAlive = true;
        logic.gameMoveSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        //Press space to go up
        if (Input.GetKeyDown(KeyCode.Space) && logic.birdAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    //Game Over Trigger
    private void OnCollisionEnter2D(Collision2D collision){
        if (logic.birdAlive == true){
            logic.gameOver();
        }
        logic.birdAlive = false;
    }
}
