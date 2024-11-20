using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Action<string> OnNewDialogueLine;

    private DialogueSO currentDialogue;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReadDialogue(DialogueSO dialogueSO)
    {
        currentDialogue = dialogueSO;
        currentDialogue.Reset();
        ReadNextLine();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ReadNextLine();
        }
    }

    private void ReadNextLine()
    {
        if (currentDialogue && currentDialogue.HasMoreLines())
        {
            OnNewDialogueLine?.Invoke(currentDialogue.GetDialogueLine());
        }
    }
}
