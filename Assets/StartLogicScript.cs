using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartLogicScript : MonoBehaviour
{
    
    public int highScore;
    public int oranges;
    public TMP_Text scoreResetText;
    public TMP_Text orangesResetText;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        oranges = PlayerPrefs.GetInt("Oranges");
    }
    public void resetHighScore(){
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void resetOranges(){
        PlayerPrefs.SetInt("Oranges", 0);
    }

    public void highScoreButton(){
        highScore = PlayerPrefs.GetInt("HighScore");
        scoreResetText.text = "Reset Highscore (" + highScore + ")?";
    }

    public void orangesButton(){
        oranges = PlayerPrefs.GetInt("Oranges");
        orangesResetText.text = "Reset Oranges (" + oranges + ")?";
    }
}
