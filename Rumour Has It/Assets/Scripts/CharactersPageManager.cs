using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharactersPageManager : MonoBehaviour
{
    [SerializeField] GameObject page;
    [SerializeField] Image picture;
    [SerializeField] TMP_Text chName;
    [SerializeField] TMP_Text chProfession;
    [SerializeField] TMP_Text assignedRumour;

    public void OpenCharacter(CharacterButton characterToOpen)
    {
        page.SetActive(true);

        CharacterSO assignedCh = characterToOpen.GetCharacterInfo();
        picture.sprite = assignedCh.GetImage();
        chName.SetText(assignedCh.GetCharacterName());
        chProfession.SetText(assignedCh.GetProfession().ToString());
    }
}
