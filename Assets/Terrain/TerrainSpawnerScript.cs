using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawnerScript : MonoBehaviour
{
    public GameObject terrain;
    public float spawnRate = 10;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrain();
    }

    // Update is called once per frame
    void Update()
    {
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