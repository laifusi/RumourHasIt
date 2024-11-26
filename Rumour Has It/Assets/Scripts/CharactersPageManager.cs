using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactersPageManager : MonoBehaviour
{
    [SerializeField] GameObject page;
    [SerializeField] Image picture;
    [SerializeField] TMP_Text chName;
    [SerializeField] TMP_Text chProfession;
    [SerializeField] TMP_Text assignedRumour;
    [SerializeField] GameObject assignedRmPanel;
    [SerializeField] GameObject assignRmButton;

    private CharacterSO openCharacter;

    // TEMPORARY SOLUTION ONLY FOR TESTING
    [SerializeField] CharacterSO[] allCharacters;

    private void Start()
    {
        // TEMPORARY SOLUTION ONLY FOR TESTING
        foreach (CharacterSO character in allCharacters)
        {
            character.Refresh();
        }
    }

    public void OpenCharacter(CharacterButton characterToOpen)
    {
        page.SetActive(true);

        openCharacter = characterToOpen.GetCharacterInfo();
        FillCharacterSection();
        FillAssignedRumourSection();
    }

    private void FillAssignedRumourSection()
    {
        bool hasChoice = openCharacter.HasPlayerCharacterChoice();
        if (hasChoice)
        {
            assignedRumour.SetText(openCharacter.GetPlayersChoice().GetRumour());
        }
        assignedRmPanel.SetActive(hasChoice);
        assignRmButton.SetActive(!hasChoice);
    }

    private void FillCharacterSection()
    {
        picture.sprite = openCharacter.GetImage();
        chName.SetText(openCharacter.GetCharacterName());
        chProfession.SetText(openCharacter.GetProfession().ToString());
    }

    public void AssignRumourToCharacter(RumourButton chosenRumour)
    {
        RumourSO rumourToAssign = chosenRumour.GetRumourInfo();
        rumourToAssign.SetPlayersCharacterChoice(openCharacter);
        openCharacter.SetPlayersRumourChoice(rumourToAssign);
        FillAssignedRumourSection();
    }

    public void RemoveAssignedRumourFromCharacter()
    {
        RumourSO removedRumour = openCharacter.RemovePlayersChoice();
        removedRumour.RemovePlayersChoice();
        FillAssignedRumourSection();
    }
}
