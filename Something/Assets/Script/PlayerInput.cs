using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float InputX { get; private set; }
    public float InputY { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }
    public bool KeyDownE { get; private set; }
    public bool KeyDownI { get; private set; }

    void Start()
    {
        InputX = 0f;
        InputY = 0f;
        MouseX = 0f;
        MouseY = 0f;
        KeyDownE = false;
        KeyDownI = false;
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        KeyDownE = Input.GetKeyDown(KeyCode.E);
        KeyDownI = Input.GetKeyDown(KeyCode.I);
    }
}