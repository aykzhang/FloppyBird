using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StartLogicScript : MonoBehaviour
{
    
    public int highScore, totalOranges;
    public TMP_Text scoreResetText, orangesResetText;
    public SaveObject saveData;


    // Start is called before the first frame update
    void Start()
    {
        saveData = SaveManager.Load();
        highScore = saveData.highScore;
        totalOranges = saveData.oranges;
    }
    public void resetHighScore(){
        saveData.highScore = 0;
        SaveManager.Save(saveData);
    }

    public void resetOranges(){
        saveData.oranges = 0;
        SaveManager.Save(saveData);
    }

    //Displays the current highscore count when the "Reset Highscore" Button is pressed
    public void highScoreButton(){
        highScore = saveData.highScore;
        scoreResetText.text = "Reset Highscore (" + highScore + ")?";
    }

    //Displays the current oranges count when the "Reset Oranges" Button is pressed
    public void orangesButton(){
        totalOranges = saveData.oranges;
        orangesResetText.text = "Reset Oranges (" + totalOranges + ")?";
    }

}
