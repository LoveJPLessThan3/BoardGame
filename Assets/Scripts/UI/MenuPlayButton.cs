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
        //передаем в LoadMenuSceneState количество игроков, затем переходим на новый стэйт
        PlayButtonPressed?.Invoke(_menuDropdown.NumberOfPlayers);
    }
}