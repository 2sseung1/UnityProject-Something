using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public bool IsControlling { get; private set; }

    [SerializeField]
    private Sprite Icon;

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        IsControlling = false;
    }

    public void GetControl(bool control)
    {
        Cursor.visible = control;
        if (control)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        IsControlling = control;
    }
}