using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Character", menuName = "Character")]
public class CharacterSO : ScriptableObject
{
    [SerializeField] Sprite image;
    [SerializeField] string characterName;
    [SerializeField] Professions profession;
    [SerializeField] DialogueSO dialogue;

    private RumourSO playersChoice;

    public void Refresh()
    {
        // We eliminate the player's choice at the start of the game
        playersChoice = null;
    }

    public Sprite GetImage()
    {
        return image;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public Professions GetProfession()
    {
        return profession;
    }

    public DialogueSO GetDialogue()
    {
        return dialogue;
    }

    public RumourSO GetPlayersChoice()
    {
        return playersChoice;
    }

    public void SetPlayersRumourChoice(RumourSO playersCh)
    {
        playersChoice = playersCh;
    }

    public RumourSO RemovePlayersChoice()
    {
        RumourSO rmToRemove = playersChoice;
        playersChoice = null;
        return rmToRemove;
    }

    public bool HasPlayerCharacterChoice()
    {
        return playersChoice != null;
    }
}

public enum Professions
{
    None, Cop, Musician, Teacher, Mayor
}
