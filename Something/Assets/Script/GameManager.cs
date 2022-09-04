using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool IsGamePause { get; private set; }

    [SerializeField]
    private UIManager _UIManager;
    [SerializeField]
    private CursorController _CursorController;
    [SerializeField]
    private Camera TitleCamera;
    [SerializeField]
    private Camera PlayerCamera;
    [SerializeField]
    private RainScript _RainScript;
    [SerializeField]
    private GameObject PlayerHead;
    [SerializeField]
    private PlayerRotate _PlayerRotate;
    [SerializeField]
    private GameObject TitleUI;
    [SerializeField]
    private Image Aim;

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

    public void GameStart()
    {
        StartCoroutine(StartDirection());
        TitleUI.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    private IEnumerator StartDirection()
    {
        _CursorController.GetControl(false);

        StartCoroutine(_UIManager.FadeOut(3));

        yield return new WaitForSeconds(4);

        _PlayerRotate._angleX = 0f;
        _PlayerRotate._angleY = -30f;
        PlayerHead.transform.rotation = Quaternion.Euler(new Vector3(0f, -30f, 0f));
        TitleCamera.enabled = false;
        PlayerCamera.enabled = true;
        _RainScript.Camera = PlayerCamera; 

        StartCoroutine(_UIManager.FadeIn(3));

        yield return new WaitForSeconds(4);

        _UIManager.StartPopUp(3, "W A S D - 이동\n마우스 - 플레이어 시점 회전");
        Aim.enabled = true;
    }
}