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
    public Sprite buySprite, selectSprite;
    public Button select;

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

    public string getName(int selectedCharacter){
        return saveData.characters[selectedCharacter].characterName;
    }

    public bool isUnlocked(int selectedCharacter){
        return saveData.characters[selectedCharacter].unlocked;
    }

    public string getConditions(int selectedCharacter){
        return saveData.characters[selectedCharacter].unlockString;
    }

    public void displayData(int selectedCharacter){
        cImage.sprite = characters[selectedCharacter];
        nameText.text = getName(selectedCharacter);
        if(!isUnlocked(selectedCharacter)){
            unlockText.text = getConditions(selectedCharacter);
            select.image.sprite = buySprite;
        }
        else{
            unlockText.text = "";
            select.image.sprite = selectSprite;
        }
    }
}
