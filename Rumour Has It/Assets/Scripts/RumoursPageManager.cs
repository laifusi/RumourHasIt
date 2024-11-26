using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RumoursPageManager : MonoBehaviour
{
    [SerializeField] GameObject page;
    [SerializeField] Image gossipImage;
    [SerializeField] TMP_Text gossipName;
    [SerializeField] TMP_Text rumourText;
    [SerializeField] Image assignedChImage;
    [SerializeField] TMP_Text assignedChName;

    public void OpenRumour(RumourButton rumourToOpen)
    {
        page.SetActive(true);

        RumourSO assignedRumour = rumourToOpen.GetRumourInfo();
        gossipImage.sprite = assignedRumour.GetGossip().GetImage();
        gossipName.SetText(assignedRumour.GetGossip().GetCharacterName());
        rumourText.SetText(assignedRumour.GetRumour());
        assignedChImage.sprite = assignedRumour.GetCharacterSO().GetImage();
        assignedChName.SetText(assignedRumour.GetCharacterSO().GetCharacterName());
    }
}
