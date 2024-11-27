using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RumoursPageManager : MonoBehaviour
{
    public static RumoursPageManager Instance;

    [SerializeField] RumourButton[] rumourButtons;
    [SerializeField] GameObject page;
    [SerializeField] Image gossipImage;
    [SerializeField] TMP_Text gossipName;
    [SerializeField] TMP_Text rumourText;
    [SerializeField] Image assignedChImage;
    [SerializeField] TMP_Text assignedChName;
    [SerializeField] GameObject assignedChPanel;
    [SerializeField] GameObject assignChButton;
    [SerializeField] GameObject assignChPanel;
    [SerializeField] CharacterButton characterButtonPrefab;

    private RumourSO openRumour;

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

    internal void UnlockCharacter(CharacterSO characterMet)
    {
        CharacterButton chButton = Instantiate(characterButtonPrefab, assignChPanel.transform);
        chButton.AssignCharacter(characterMet);
    }

    internal void UnlockRumour(RumourSO rumourLearnt)
    {
        for (int i = 0; i < rumourButtons.Length; i++)
        {
            if (!rumourButtons[i].HasRumour())
            {
                rumourButtons[i].AssignRumour(rumourLearnt);
                return;
            }
        }
    }
}
