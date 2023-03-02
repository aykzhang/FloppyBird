using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZoneScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        //need to tag the Logic Manager with "Logic" tab in unity
        //Then use this component to get the logic script class
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //runs whenever something enters the collider
    private void OnTriggerEnter2D(Collider2D collision){
        //assign bird to layer 3 in Unity
        //if the object is in layer 3, addscore
        if(collision.gameObject.layer == 3 && logic.birdAlive){
            logic.addScore(1);
        }       
    }
}
