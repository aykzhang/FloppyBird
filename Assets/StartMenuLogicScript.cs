using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class StartMenuLogicScript : MonoBehaviour
{
    public Image cImage;
    public List<Sprite> characters = new List<Sprite>();
    private int selectedCharacter;
    public SaveObject saveData;
    public TMP_Text nameText, unlockText, totalOrangesText, descriptionText;
    public Button select, buy;
    public Sprite buySprite, notEnoughSprite;
    public int highScore, totalOranges;
    public TMP_Text scoreResetText, orangesResetText;

    void Start(){
        saveData = SaveManager.Load();
        highScore = saveData.highScore;
        totalOranges = saveData.oranges;
    }

    public void Open()
    {
        saveData = SaveManager.Load();
        selectedCharacter = saveData.selectedCharacter;
        totalOrangesText.text = saveData.oranges.ToString();
        displayData(saveData.selectedCharacter);
    }

    public void NextOption(){
        selectedCharacter += 1;
        if(selectedCharacter >= characters.Count){
            selectedCharacter = 0;
        }
        displayData(selectedCharacter);
    }

    public void PrevOption(){
        selectedCharacter -= 1;
        if(selectedCharacter < 0){
            selectedCharacter = characters.Count - 1;
        }
        displayData(selectedCharacter);
    }  

    public void setSelectedCharacter(){
        saveData.selectedCharacter = selectedCharacter;
        SaveManager.Save(saveData);
        displayData(selectedCharacter);
    }

    public void buyCharacter(){
        saveData.oranges -= getCharacter(selectedCharacter).cost;
        getCharacter(selectedCharacter).unlocked = true;
        SaveManager.Save(saveData);
        displayData(selectedCharacter);
    }

    public string getName(int selectedCharacter){
        return getCharacter(selectedCharacter).characterName;
    }

    public bool isUnlocked(int selectedCharacter){
        return getCharacter(selectedCharacter).unlocked;
    }

    public string getConditions(int selectedCharacter){
        return getCharacter(selectedCharacter).unlockString;
    }

    public string getDesc(int selectedCharacter){
        return getCharacter(selectedCharacter).description;
    }   

    public CharacterData getCharacter(int selectedCharacter){
        return saveData.characters[selectedCharacter];
    }

    public void displayData(int selectedCharacter){
        cImage.sprite = characters[selectedCharacter];
        nameText.text = getName(selectedCharacter);
        totalOrangesText.text = saveData.oranges.ToString();
        descriptionText.text = getDesc(selectedCharacter);
        if(!isUnlocked(selectedCharacter)){
            unlockText.text = getConditions(selectedCharacter);
            select.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            cImage.color = Color.black;
            if(saveData.oranges < getCharacter(selectedCharacter).cost){
                buy.interactable = false;
                buy.image.sprite = notEnoughSprite;
            }
            else{
                buy.interactable = true;
                buy.image.sprite = buySprite;
            }
        }
        else{
            cImage.color = Color.white;
            unlockText.text = "";
            select.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
    }

    public void resetHighScore(){
        saveData.highScore = 0;
        SaveManager.Save(saveData);
    }

    public void resetOranges(){
        saveData.oranges = 0;
        SaveManager.Save(saveData);
    }

    public void resetCharacters(){
        for(int x = 1; x < saveData.characters.Count; x++){
            saveData.characters[x].unlocked = false;
        }
        saveData.selectedCharacter = 0;
        SaveManager.Save(saveData);
    }

    public void resetAll(){
        SaveManager.Delete();
        saveData = SaveManager.Load();
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
