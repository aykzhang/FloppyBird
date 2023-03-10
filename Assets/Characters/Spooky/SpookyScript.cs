using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public SpriteRenderer sprite;
    public float timer = .5f;
    public float timeToFade = 1;
    public bool fade = true;
    public float fadeAmount = .05f;

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
        if (Input.GetKeyDown(KeyCode.Space) && logic.birdAlive)
        {
            FindObjectOfType<AudioManagerScript>().Play("Jump");
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
        Color spriteColor = sprite.color;
        if(timer < timeToFade){
            timer = timer + Time.deltaTime;
        }
        else{
            if(fade){
                if(spriteColor.a > 0){
                    spriteColor.a = spriteColor.a - fadeAmount;
                }
                else{
                    fade = false;
                }
            }

            else if(!fade){
                if(spriteColor.a < 1){
                    spriteColor.a = spriteColor.a + fadeAmount;
                }
                else{
                    fade = true;
                }
            }
            sprite.color = spriteColor;
            timer = 0;
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
