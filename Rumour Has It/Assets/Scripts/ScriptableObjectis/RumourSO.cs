using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Rumour", menuName = "Rumour")]
public class RumourSO : ScriptableObject
{
    [SerializeField] string rumour;
    [SerializeField] CharacterSO character;

    private CharacterSO gossip;
    private CharacterSO playersChoice;
    private bool wasLearnt;

    public void Refresh()
    {
        // We eliminate the player's choice at the start of the game
        playersChoice = null;
        wasLearnt = false;
    }

    public string GetRumour()
    {
        return rumour;
    }

    public CharacterSO GetCharacterSO()
    {
        return character;
    }

    public CharacterSO GetGossip()
    {
        return gossip;
    }

    public void SetGossip(CharacterSO rumourGossip)
    {
        gossip = rumourGossip;
    }

    public CharacterSO GetPlayersCharacterChoice()
    {
        return playersChoice;
    }

    public void SetPlayersCharacterChoice(CharacterSO playersCh)
    {
        playersChoice = playersCh;
    }

    public CharacterSO RemovePlayersChoice()
    {
        CharacterSO chToRemove = playersChoice;
        playersChoice = null;
        return chToRemove;
    }

    public bool HasPlayerCharacterChoice()
    {
        return playersChoice != null;
    }

    public void SetWasLearnt()
    {
        wasLearnt = true;
    }

    public bool HasBeenLearnt()
    {
        return wasLearnt;
    }
}
