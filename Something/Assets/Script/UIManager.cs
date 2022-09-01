using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager _GameManager;
    [SerializeField]
    private PauseMenuController _PauseMenuController;
    [SerializeField]
    private InventoryController _InventoryController;

    private bool _menuActive;
    private IMenu _activatingMenu;
    private KeyCode _recentInputKey;

    void Start()
    {
        _menuActive = false;
        _activatingMenu = null;
        _recentInputKey = KeyCode.None;
    }

    public void MenuControl(KeyCode keyDownCode)
    {
        if (_menuActive)
        {
            _activatingMenu.ViewOnOff(false);

            if (_recentInputKey == keyDownCode)
            {
                _GameManager.ActivateGame(true);
                _menuActive = false;
                _activatingMenu = null;
                _recentInputKey = KeyCode.None;

                return;
            }
        }
        else
        {
            _GameManager.ActivateGame(false);
        }

        switch (keyDownCode)
        {
            case KeyCode.I:
                _InventoryController.ViewOnOff(true);
                _activatingMenu = _InventoryController;
                break;
        }

        _menuActive = true;
        _recentInputKey = keyDownCode;
    }

    public void PauseKeyInteraction()
    {
        if (_menuActive)
        {
            _activatingMenu.ViewOnOff(false);
            _menuActive = false;
            _activatingMenu = null;
            _recentInputKey = KeyCode.None;
            _GameManager.ActivateGame(true);

            return;
        }
        else
        {
            EscapeMenuViewOn();
        }
    }

    private void EscapeMenuViewOn()
    {
        _PauseMenuController.ViewOnOff(true);
        _menuActive = true;
        _activatingMenu = (IMenu)_PauseMenuController;
        _recentInputKey = KeyCode.Escape;
        _GameManager.ActivateGame(false);
    }
}