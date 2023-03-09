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
        new CharacterData{unlocked = true, cost = 0, unlockString = "", characterName = "Bird", description = "Bird is currently having a quarter life crisis. He doesn't know what he wants to be."},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Flippy", description = "Flippy doesn't believe in gravity."},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Zippy", description = "The problem of being faster than light is that you can only live in darkness."},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Spooky", description = "Spooky ate Absalom's devil fruit."},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Flighty", description = "You just activated my flight or fight response, and I am a flightless bird."}
    };

}
