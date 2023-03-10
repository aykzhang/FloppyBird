using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawnerScript : MonoBehaviour
{
    public GameObject terrain;
    public float spawnRate = 10;
    private float timer = 0;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Instantiate(terrain, new Vector3(4.897408f ,1.008987f ,-0.2391459f), transform.rotation);
        SpawnTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = 5f * (10f / logic.gameMoveSpeed);
        //If timer < spawnrate, timer goes up
        if (timer < spawnRate)
        {       
            timer = timer + Time.deltaTime;
        }
        //If timer => spawnrate, spawn and reset timer
        else
        {
            SpawnTerrain();
            timer = 0;
        }   
    }

    void SpawnTerrain(){
        Instantiate(terrain, transform.position, transform.rotation);
    }
}