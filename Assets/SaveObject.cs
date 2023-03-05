using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public int highScore;
    public int oranges;
    public int selectedCharacter;
    public List<int> unlockedCharacters = new List<int> {1};

}
