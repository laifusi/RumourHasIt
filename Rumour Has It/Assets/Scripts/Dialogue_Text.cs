using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_Text : MonoBehaviour
{
    TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        DialogueManager.Instance.OnNewDialogueLine += SetDialogueText;
        DialogueManager.Instance.OnEndDialogue += RemoveDialogueText;
    }

    private void SetDialogueText(string dialogueLine)
    {
        text.SetText(dialogueLine);
    }

    private void RemoveDialogueText()
    {
        text.SetText("");
    }

    private void OnDestroy()
    {
        DialogueManager.Instance.OnNewDialogueLine -= SetDialogueText;
    }
}
