using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public bool IsControlling { get; private set; }

    [SerializeField]
    private Sprite Icon;

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