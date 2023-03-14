using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeScript : MonoBehaviour
{
    public LogicScript logic;
    public float deadZone = -40;
    public float moveSpeed;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        moveSpeed = logic.gameMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        updateSpeed();
        //move left
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //Despawn if pipe is too far left
        if(transform.position.x < deadZone){
            //Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }

    //Add one to oranges when bird collides with an orange
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 3 && logic.birdAlive && !(animator.GetBool("Collected"))){
            animator.SetBool("Collected" , true);
            FindObjectOfType<AudioManagerScript>().Play("Orange");
            logic.addOranges(1);
        }     
    }

    public void updateSpeed(){
        moveSpeed = logic.gameMoveSpeed; 
    }
}
