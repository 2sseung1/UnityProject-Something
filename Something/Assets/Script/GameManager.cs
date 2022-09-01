using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGamePause { get; private set; }

    [SerializeField]
    private UIManager _UIManager;
    [SerializeField]
    private CursorController _CursorController;

    void Awake()
    {
        IsGamePause = false;
    }

    public void ActivateGame(bool active)
    {
        if (active)
        {
            _CursorController.GetControl(false);
            GameResume();
        }
        else
        {
            _CursorController.GetControl(true);
            GamePause();
        }
    }

    private void GamePause()
    {
        IsGamePause = true;
        Time.timeScale = 0f;
    }

    private void GameResume()
    {
        IsGamePause = false;
        Time.timeScale = 1f;
    }
}