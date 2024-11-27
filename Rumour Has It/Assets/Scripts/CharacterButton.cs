using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    private CharacterSO character;

    private Button button;
    private GameObject assignmentPanel;

    private void Awake()
    {
        assignmentPanel = transform.parent.gameObject;
        button = GetComponent<Button>();
        button.interactable = character != null;
    }

    public void AssignCharacter(CharacterSO characterSO)
    {
        character = characterSO;
        if(button != null)
            button.interactable = true;
    }

    public CharacterSO GetCharacterInfo()
    {
        return character;
    }

    public bool HasCharacter()
    {
        return character != null;
    }

    public void CloseAssignmentPanel()
    {
        assignmentPanel.SetActive(false);
    }

    public void AssignCharacterToRumour()
    {
        RumoursPageManager.Instance.AssignCharacterToRumour(this);
    }
}
