using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] CharacterSO character;

    private bool canRead = true;

    private void Start()
    {
        DialogueManager.Instance.OnEndDialogue += FinishedReading;

        // This character knows they are the gossip of a specific rumour.
        // To avoid manual mistakes, the gossip is assigned in each rumour SO via code.
        character.GetDialogue().GetRumour().SetGossip(character);
    }

    public void SpeakTo()
    {
        DialogueSO dialogue = character.GetDialogue();
        if (dialogue && canRead)
        {
            DialogueManager.Instance.ReadDialogue(dialogue);
            canRead = false;
        }
    }

    private void FinishedReading(DialogueSO dialogueRead)
    {
        if (dialogueRead != character.GetDialogue())
            return;

        canRead = true;
        GameManager.Instance.UnlockCharacter(character);
    }

    private void OnMouseDown()
    {
        SpeakTo();
    }

    private void OnDestroy()
    {
        DialogueManager.Instance.OnEndDialogue -= FinishedReading;
    }
}
