using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public float flapBase;
    public float boostStrength = 1f;
    public LogicScript logic;
    public SpriteRenderer sr;
    public Sprite flightySprite;
    public Sprite flightSpriteFire;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.birdAlive = true;
        logic.gameMoveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Hold space to go up
        if(Input.GetKeyDown(KeyCode.Space) && logic.birdAlive){
            FindObjectOfType<AudioManagerScript>().Play("Flight");
        }
        if (Input.GetKey(KeyCode.Space) && logic.birdAlive)
        {
            sr.sprite = flightSpriteFire;
            myRigidBody.velocity = Vector2.up * flapStrength;
            flapStrength = flapStrength + boostStrength + Time.deltaTime;
        }
        else{
            FindObjectOfType<AudioManagerScript>().Stop("Flight");
            sr.sprite = flightySprite;
            flapStrength = flapBase;
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
