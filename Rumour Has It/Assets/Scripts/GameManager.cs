using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] RumourSO[] allRumours;
    [SerializeField] CharacterSO[] allCharacters;
    [SerializeField] GameObject[] allLocations;
    [SerializeField] GameObject initialLocation;

    GameObject currentLocation;

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
}
