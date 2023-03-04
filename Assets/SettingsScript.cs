using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public int highScore;
    public int oranges;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        oranges = PlayerPrefs.GetInt("Oranges");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
