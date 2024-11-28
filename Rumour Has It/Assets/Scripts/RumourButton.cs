using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RumourButton : MonoBehaviour
{
    private RumourSO rumour;

    private Button button;
    private TMP_Text rumourText;
    private GameObject assignmentPanel;

    private void Awake()
    {
        assignmentPanel = transform.parent.gameObject;
        button = GetComponent<Button>();
        rumourText = GetComponentInChildren<TMP_Text>();
        button.interactable = rumour != null;
        rumourText.SetText(rumour ? rumour.GetRumour() : "");
    }

    public void AssignRumour(RumourSO rumourSO)
    {
        rumour = rumourSO;
        if(button != null)
            button.interactable = true;
        
        if(rumourText != null)
            rumourText.SetText(rumour.GetRumour());
    }

    public RumourSO GetRumourInfo()
    {
        return rumour;
    }

    public bool HasRumour()
    {
        return rumour != null;
    }

    public void CloseAssignmentPanel()
    {
        assignmentPanel.SetActive(false);
    }
    public void AssignRumourToCharacter()
    {
        CharactersPageManager.Instance.AssignRumourToCharacter(this);
    }
}
