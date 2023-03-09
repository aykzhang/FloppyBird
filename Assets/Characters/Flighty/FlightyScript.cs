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
        //Press space to go up
        if (Input.GetKey(KeyCode.Space) && logic.birdAlive)
        {
            sr.sprite = flightSpriteFire;
            myRigidBody.velocity = Vector2.up * flapStrength;
            flapStrength = flapStrength + boostStrength + Time.deltaTime;
        }
        else{
            sr.sprite = flightySprite;
            flapStrength = flapBase;
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
