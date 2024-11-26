using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Action<string> OnNewDialogueLine;
    public Action OnEndDialogue;

    private DialogueSO currentDialogue;
    private bool canRead = false;

    [SerializeField] GameObject DialogueUI;

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
        currentDialogue.Refresh();

        StartCoroutine(InitiateDialogue());
    }

    IEnumerator InitiateDialogue()
    {
        DialogueUI.SetActive(true);
        yield return null;
        canRead = true;
        ReadNextLine();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ReadNextLine();
        }
    }

    public void ReadNextLine()
    {
        if (!currentDialogue || !canRead)
            return;

        if (currentDialogue.HasMoreLines())
        {
            OnNewDialogueLine?.Invoke(currentDialogue.GetDialogueLine());
        }
        else
        {
            OnEndDialogue?.Invoke();
            currentDialogue = null;
            canRead = false;
            DialogueUI.SetActive(false);
        }
    }
}
