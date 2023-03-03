using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeScript : MonoBehaviour
{
    public LogicScript logic;
    public float deadZone = -40;
    public float moveSpeed = 5;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //move left
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //Despawn if pipe is too far left
        if(transform.position.x < deadZone){
            //Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        //assign bird to layer 3 in Unity
        //if the object is in layer 3, addscore
        if(collision.gameObject.layer == 3 && logic.birdAlive && !(animator.GetBool("Collected"))){
            animator.SetBool("Collected" , true);
            logic.addOranges(1);
        }     
    }
}
