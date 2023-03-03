using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public int playerOranges;
    public int totalOranges;
    public TMP_Text scoreText;
    public TMP_Text orangesText;
    public TMP_Text highScoreText;
    public TMP_Text totalOrangesText;
    public bool birdAlive;
    public GameObject gameOverScreen;
 
    void Start(){
        highScore = PlayerPrefs.GetInt("HighScore");
        totalOranges = PlayerPrefs.GetInt("Oranges");
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
        if(playerScore > highScore){
            highScore = playerScore;   
        }
        totalOranges += playerOranges;

        saveData(highScore,totalOranges);
        highScoreText.text = "High Score: " + highScore.ToString();
        totalOrangesText.text = "Total Oranges: " + totalOranges.ToString();
        gameOverScreen.SetActive(true);
    }

    public void saveData(int score, int oranges){
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.SetInt("Oranges", oranges);
    }
}
