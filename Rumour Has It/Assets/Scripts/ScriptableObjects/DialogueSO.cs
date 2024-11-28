using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Dialogue", menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
    [SerializeField] List<string> dialogue = new List<string>();
    [SerializeField] RumourSO rumour;

    private int currentLine = 0;

    public void Refresh()
    {
        currentLine = 0;
    }

    public string GetDialogueLine()
    {
        currentLine++;
        return dialogue[currentLine - 1];
    }

    public bool HasMoreLines()
    {
        return dialogue.Count > currentLine;
    }

    public RumourSO GetRumour()
    {
        return rumour;
    }
}
