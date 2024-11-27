using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RumoursPageManager : MonoBehaviour
{
    [SerializeField] GameObject page;
    [SerializeField] Image gossipImage;
    [SerializeField] TMP_Text gossipName;
    [SerializeField] TMP_Text rumourText;
    [SerializeField] Image assignedChImage;
    [SerializeField] TMP_Text assignedChName;
    [SerializeField] GameObject assignedChPanel;
    [SerializeField] GameObject assignChButton;

    private RumourSO openRumour;

    public void OpenRumour(RumourButton rumourToOpen)
    {
        page.SetActive(true);

        openRumour = rumourToOpen.GetRumourInfo();
        FillRumourSection();
        FillAssignedCharacterSection();
    }

    private void FillRumourSection()
    {
        gossipImage.sprite = openRumour.GetGossip().GetImage();
        gossipName.SetText(openRumour.GetGossip().GetCharacterName());
        rumourText.SetText(openRumour.GetRumour());
    }

    private void FillAssignedCharacterSection()
    {
        bool hasChoice = openRumour.HasPlayerCharacterChoice();
        if (hasChoice)
        {
            assignedChImage.sprite = openRumour.GetPlayersCharacterChoice().GetImage();
            assignedChName.SetText(openRumour.GetPlayersCharacterChoice().GetCharacterName());
        }
        assignedChPanel.SetActive(hasChoice);
        assignChButton.SetActive(!hasChoice);
    }

    public void AssignCharacterToRumour(CharacterButton chosenCharacter)
    {
        CharacterSO characterToAssign = chosenCharacter.GetCharacterInfo();
        openRumour.SetPlayersCharacterChoice(characterToAssign);
        characterToAssign.SetPlayersRumourChoice(openRumour);
        FillAssignedCharacterSection();
    }

    public void RemoveAssignedCharacterFromRumour()
    {
        CharacterSO removedCharacter = openRumour.RemovePlayersChoice();
        removedCharacter.RemovePlayersChoice();
        FillAssignedCharacterSection();
    }
}
