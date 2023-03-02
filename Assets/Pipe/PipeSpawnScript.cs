using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 5;
    private float timer = 0;
    public float heightOffset = 8;
    // Start is called before the first frame update
    public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        float multiplier = (100f-logic.playerScore)/100;

        //Debug.Log("score: " + logic.playerScore + " multiplier: " + multiplier);
        if (multiplier < .5f){
            multiplier = .5f;
        }
        //If timer < spawnrate, timer goes up
        if (timer < spawnRate * multiplier)
        {       
            timer = timer + Time.deltaTime;
        }
        //If timer => spawnrate, spawn and reset timer
        else
        {
            SpawnPipe();
            timer = 0;
        }   
    }

    void SpawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }
}
