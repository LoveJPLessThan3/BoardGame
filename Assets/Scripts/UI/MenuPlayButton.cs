using System;
using UnityEngine;

public class MenuPlayButton : MonoBehaviour
{
    [SerializeField]
    private MenuDropdown _menuDropdown;


    public static event Action<int> PlayButtonPressed;

    public void MenuPlayButtonClick()
    {
        Time.timeScale = 1;
        PlayButtonPressed?.Invoke(_menuDropdown.NumberOfPlayers);
    }


}