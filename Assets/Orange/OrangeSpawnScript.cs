using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawnScript : MonoBehaviour
{
    public GameObject orange;
    public float spawnRate = 8;
    private float timer = 0;
    public float heightOffset = 8;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {       
            timer = timer + Time.deltaTime;
        }
        //If timer => spawnrate, spawn and reset timer
        else
        {
            SpawnOrange();
            timer = 0;
            spawnRate = Random.Range(10, 20);
        }
    }
    void SpawnOrange(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(orange, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }
}
