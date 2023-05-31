using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDropdown : MonoBehaviour
{
    public int NumberOfPlayers { get; private set; }

    private void Awake()
    {
        NumberOfPlayers = 4;
    }

    public void HandleInputData(int val)
    {
        NumberOfPlayers = val + 2;
        Debug.Log(NumberOfPlayers);
    }
}
