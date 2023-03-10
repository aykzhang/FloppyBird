using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore, highScore, playerOranges, totalOranges, gameMoveSpeed;
    public TMP_Text scoreText, orangesText, highScoreText, totalOrangesText;
    public bool birdAlive;
    public GameObject gameOverScreen;
    public SaveObject saveData;
 
    void Start(){
        saveData = SaveManager.Load();
        highScore = saveData.highScore;
        totalOranges = saveData.oranges;
        FindObjectOfType<AudioManagerScript>().Play("Main Game Theme");
    }
    
    //makes it possible to call function in unity with the extra menu on top right
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void addOranges(int orangesToAdd){
        playerOranges += orangesToAdd;
        orangesText.text = "Oranges: " + playerOranges.ToString();
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    public void gameOver(){
        //Checks for highscore and oranges
        if(playerScore > highScore){
            highScore = playerScore;   
        }
        totalOranges += playerOranges;

        //Saves any data from run
        saveData.highScore = highScore;
        saveData.oranges = totalOranges;

        SaveManager.Save(saveData);

        //Display Game Over Screen
        highScoreText.text = "High Score: " + highScore.ToString();
        totalOrangesText.text = "Total Oranges: " + totalOranges.ToString();
        gameOverScreen.SetActive(true);
    }
}
