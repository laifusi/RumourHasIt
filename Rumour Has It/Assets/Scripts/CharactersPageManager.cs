using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactersPageManager : MonoBehaviour
{
    public static CharactersPageManager Instance;

    [SerializeField] CharacterButton[] characterButtons;
    [SerializeField] GameObject page;
    [SerializeField] Image picture;
    [SerializeField] TMP_Text chName;
    [SerializeField] TMP_Text chProfession;
    [SerializeField] TMP_Text assignedRumour;
    [SerializeField] GameObject assignedRmPanel;
    [SerializeField] GameObject assignRmButton;
    [SerializeField] GameObject assignRmPanel;
    [SerializeField] RumourButton rumourButtonPrefab;

    private CharacterSO openCharacter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
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

    internal void UnlockCharacter(CharacterSO characterMet)
    {
        for(int i = 0; i < characterButtons.Length; i++)
        {
            if (!characterButtons[i].HasCharacter())
            {
                characterButtons[i].AssignCharacter(characterMet);
                return;
            }
        }
    }

    internal void UnlockRumour(RumourSO rumourLearnt)
    {
        RumourButton rmButton = Instantiate(rumourButtonPrefab, assignRmPanel.transform);
        rmButton.AssignRumour(rumourLearnt);
    }
}
