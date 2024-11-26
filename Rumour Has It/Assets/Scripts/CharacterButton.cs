using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] //JUST FOR TESTING
    private CharacterSO character;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        // JUST FOR TESTING
        button.interactable = character != null;
    }

    public void AssignCharacter(CharacterSO characterSO)
    {
        character = characterSO;
        button.interactable = true;
    }

    public CharacterSO GetCharacterInfo()
    {
        return character;
    }
}
