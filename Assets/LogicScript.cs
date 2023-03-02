using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public bool birdAlive;
    public GameObject gameOverScreen;
    
    //makes it possible to call function in unity with the extra menu on top right
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
    }
}
