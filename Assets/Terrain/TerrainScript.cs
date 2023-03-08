using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone = -65;
    public LogicScript logic;
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

    public void updateSpeed(){
        moveSpeed = logic.gameMoveSpeed; 
    }
}
