using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerScript : MonoBehaviour
{
    public LogicScript logic;
    public List<GameObject> characters;
    public SaveObject saveData;
    GameObject chosenCharacter;
    // Start is called before the first frame update
    void Start()
    {
        saveData = SaveManager.Load();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        GameObject chosenCharacter = characters[saveData.selectedCharacter];
        SpawnCharacter(chosenCharacter);
    }

    void SpawnCharacter(GameObject player){
        Instantiate(player, transform.position, transform.rotation);
    }
}
