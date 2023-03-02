using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    // Start is called before the first frame update
    public float deadZone = -40;
    void Start()
    {
        
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
}
