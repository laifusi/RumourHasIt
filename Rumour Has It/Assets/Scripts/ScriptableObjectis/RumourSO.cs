using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Rumour", menuName = "Rumour")]
public class RumourSO : ScriptableObject
{
    [SerializeField] string rumour;
    [SerializeField] CharacterSO character;

    public string GetRumour()
    {
        return rumour;
    }

    public CharacterSO GetCharacterSO()
    {
        return character;
    }
}
