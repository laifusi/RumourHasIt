using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    private CharacterSO character;

    private Button button;
    private Image characterImage;
    private GameObject assignmentPanel;

    private void Awake()
    {
        assignmentPanel = transform.parent.gameObject;
        button = GetComponent<Button>();
        characterImage = GetComponent<Image>();
        button.interactable = character != null;
        characterImage.sprite = character ? character.GetImage() : null;
    }

    public void AssignCharacter(CharacterSO characterSO)
    {
        character = characterSO;
        if(button != null)
            button.interactable = true;
        
        if(characterImage != null)
            characterImage.sprite = character.GetImage();
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
