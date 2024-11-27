using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class RumourButton : MonoBehaviour
{
    private RumourSO rumour;

    private Button button;
    private GameObject assignmentPanel;

    private void Awake()
    {
        assignmentPanel = transform.parent.gameObject;
        button = GetComponent<Button>();
        button.interactable = rumour != null;
    }

    public void AssignRumour(RumourSO rumourSO)
    {
        rumour = rumourSO;
        if(button != null)
            button.interactable = true;
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
