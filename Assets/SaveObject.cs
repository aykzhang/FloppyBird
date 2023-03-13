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
        new CharacterData{unlocked = true, cost = 0, unlockString = "", characterName = "Bird", description = "Bird is currently having a quarter life crisis. He doesn't know what he wants to be.", characterHighScore = 0, characterOrangeTotal = 0},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Flippy", description = "Flippy doesn't believe in gravity.", characterHighScore = 0, characterOrangeTotal = 0},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Zippy", description = "The problem of being faster than light is that you can only live in darkness.", characterHighScore = 0, characterOrangeTotal = 0},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Spooky", description = "Spooky ate Absalom's devil fruit.", characterHighScore = 0, characterOrangeTotal = 0},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Flighty", description = "You just activated my flight or fight response, and I am a flightless bird.", characterHighScore = 0, characterOrangeTotal = 0},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Turny", description = "Turny always goes where he's looking.", characterHighScore = 0, characterOrangeTotal = 0},
        new CharacterData{unlocked = false, cost = 40, unlockString = "Spend 40 oranges to unlock", characterName = "Randy", description = "Randy is a thinker. What is gravity? What came first?", characterHighScore = 0, characterOrangeTotal = 0}
    };

}
