using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawnScript : MonoBehaviour
{
    public GameObject orange;
    public GameObject orangeBasket;
    public float spawnRate = 5;
    private float timer = -3;
    public float heightOffset = 8;
    public LogicScript logic;
    public int basketChance = 30;
    private float initialSpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        initialSpawnRate = spawnRate;
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
            int rng = Random.Range(1, 100);
            if (rng < basketChance){
                SpawnOrangeBasket();
            }
            else{
                SpawnOrange();
            }
            timer = 0;
            spawnRate = Random.Range(1, 3) * initialSpawnRate;
        }
    }
    void SpawnOrange(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(orange, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }
    void SpawnOrangeBasket(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(orangeBasket, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint),0), transform.rotation);
    }   
}
