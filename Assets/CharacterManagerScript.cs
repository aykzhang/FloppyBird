using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class CharacterManagerScript : MonoBehaviour
{
    public Image cImage;
    public List<Sprite> characters = new List<Sprite>();
    private int selectedCharacter = 0;
    public SaveObject saveData;
    public TMP_Text nameText, unlockText, totalOranges;
    public Button select, buy;
    public Sprite buySprite, notEnoughSprite;

    void Start()
    {
        saveData = SaveManager.Load();
        totalOranges.text = saveData.oranges.ToString();
    }

    public void NextOption(){
        selectedCharacter += 1;
        if(selectedCharacter == characters.Count){
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

    public CharacterData getCharacter(int selectedCharacter){
        return saveData.characters[selectedCharacter];
    }

    public void displayData(int selectedCharacter){
        cImage.sprite = characters[selectedCharacter];
        nameText.text = getName(selectedCharacter);
        totalOranges.text = saveData.oranges.ToString();
        if(!isUnlocked(selectedCharacter)){
            unlockText.text = getConditions(selectedCharacter);
            select.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
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
            unlockText.text = "";
            select.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }
    }
}
