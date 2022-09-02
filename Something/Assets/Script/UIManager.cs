using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager _GameManager;
    [SerializeField]
    private PauseMenuController _PauseMenuController;
    [SerializeField]
    private InventoryController _InventoryController;
    [SerializeField]
    private Image Background;

    private bool _menuActive;
    private IMenu _activatingMenu;
    private KeyCode _recentInputKey;

    void Start()
    {
        _menuActive = false;
        _activatingMenu = null;
        _recentInputKey = KeyCode.None;

        StartCoroutine(FadeIn(5));
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

    IEnumerator FadeIn(float time)
    {
        float plusValue = 1 / time;
        float alphaValue = Background.color.a;
        Color color = new Color(0f, 0f, 0f, Background.color.a);

        while (0 < Background.color.a)
        {
            alphaValue -= plusValue * Time.deltaTime;
            color.a = alphaValue;
            Background.color = color;

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator FadeOut(float time)
    {
        float plusValue = 1 / time;
        float alphaValue = Background.color.a;
        Color color = new Color(0f, 0f, 0f, Background.color.a);

        while (Background.color.a < 1)
        {
            alphaValue += plusValue * Time.deltaTime;
            color.a = alphaValue;
            Background.color = color;

            yield return new WaitForFixedUpdate();
        }
    }
}