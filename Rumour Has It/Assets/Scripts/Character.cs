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

    private void FinishedReading()
    {
        canRead = true;
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
