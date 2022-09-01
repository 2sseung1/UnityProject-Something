using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour, IMenu
{
    public bool ViewActive { get; private set; }

    [SerializeField]
    private GameObject PauseMenuView;

    public void ViewOnOff(bool onOff)
    {
        PauseMenuView.SetActive(onOff);
        ViewActive = onOff;
    }
}