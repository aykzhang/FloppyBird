using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore, highScore, playerOranges, totalOranges, gameMoveSpeed, characterHighScore, characterOranges;
    public TMP_Text scoreText, orangesText, highScoreText, totalOrangesText, instructionsText;
    public bool birdAlive;
    public GameObject gameOverScreen;
    public SaveObject saveData;
 
    void Start(){
        saveData = SaveManager.Load();
        //overall highscore and oranges
        highScore = saveData.highScore;
        totalOranges = saveData.oranges;
        //character specific highscore and oranges
        characterHighScore = saveData.characters[saveData.selectedCharacter].characterHighScore;
        characterOranges = saveData.characters[saveData.selectedCharacter].characterOrangeTotal;
        //display instructions
        instructionsText.text = saveData.characters[saveData.selectedCharacter].instructions;
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
        //Check character highscore and oranges
        if(playerScore > characterHighScore){
            characterHighScore = playerScore;
        }
        characterOranges += playerOranges;

        //Checks for overall highscore and oranges
        if(playerScore > highScore){
            highScore = playerScore;   
        }
        totalOranges += playerOranges;

        //Saves any data from run
        saveData.highScore = highScore;
        saveData.oranges = totalOranges;
        saveData.characters[saveData.selectedCharacter].characterHighScore = characterHighScore;
        saveData.characters[saveData.selectedCharacter].characterOrangeTotal = characterOranges;

        SaveManager.Save(saveData);

        //Display Game Over Screen
        highScoreText.text = "High Score: " + highScore.ToString();
        totalOrangesText.text = "Total Oranges: " + totalOranges.ToString();
        gameOverScreen.SetActive(true);
    }
}
