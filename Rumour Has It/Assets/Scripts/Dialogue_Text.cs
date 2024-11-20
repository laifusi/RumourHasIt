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
    }

    private void SetDialogueText(string dialogueLine)
    {
        text.SetText(dialogueLine);
    }

    private void OnDestroy()
    {
        DialogueManager.Instance.OnNewDialogueLine -= SetDialogueText;
    }
}
