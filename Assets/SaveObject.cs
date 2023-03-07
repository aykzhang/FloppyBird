using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public int highScore;
    public int oranges;
    public int selectedCharacter = 0;
    public List<CharacterData> characters = new List<CharacterData>{
        new CharacterData{unlocked = true, cost = 0, unlockString = "", characterName = "Bird"},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Flippy"},
    };

}
