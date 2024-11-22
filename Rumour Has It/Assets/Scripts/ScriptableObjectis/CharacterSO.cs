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
}

public enum Professions
{
    None, Cop, Musician, Teacher, Mayor
}
