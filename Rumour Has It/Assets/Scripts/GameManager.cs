using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] RumourSO[] allRumours;
    [SerializeField] CharacterSO[] allCharacters;
    [SerializeField] GameObject[] allLocations;
    [SerializeField] GameObject initialLocation;

    GameObject currentLocation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (RumourSO rumour in allRumours)
        {
            rumour.Refresh();
        }

        foreach (CharacterSO character in allCharacters)
        {
            character.Refresh();
        }

        CloseAllLocations();
        initialLocation.SetActive(true);
        currentLocation = initialLocation;
    }

    #region Map Controls
    public void CloseAllLocations()
    {
        foreach(GameObject location in allLocations)
        {
            location.SetActive(false);
        }
    }

    public void GoToNewLocation(GameObject newLocation)
    {
        currentLocation = newLocation;
    }

    public void GoBackToCurrentLocation()
    {
        currentLocation.SetActive(true);
    }
    #endregion

    // When we meet a character, they get added to the notebook and can be assigned to a rumour
    public void UnlockCharacter(CharacterSO characterMet)
    {
        if (characterMet.HasBeenMet())
            return;

        RumourSO rumourLearnt = characterMet.GetDialogue().GetRumour();
        CharactersPageManager.Instance.UnlockCharacter(characterMet);
        RumoursPageManager.Instance.UnlockCharacter(characterMet);
        CharactersPageManager.Instance.UnlockRumour(rumourLearnt);
        RumoursPageManager.Instance.UnlockRumour(rumourLearnt);

        characterMet.SetWasMet();
        rumourLearnt.SetWasLearnt();
    }
}
