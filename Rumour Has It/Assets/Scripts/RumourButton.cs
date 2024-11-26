using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RumourButton : MonoBehaviour
{
    [SerializeField] //JUST FOR TESTING
    private RumourSO rumour;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        // JUST FOR TESTING
        button.interactable = rumour != null;
    }

    public void AssignRumour(RumourSO rumourSO)
    {
        rumour = rumourSO;
        button.interactable = true;
    }

    public RumourSO GetRumourInfo()
    {
        return rumour;
    }
}
