using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public float InputX { get; private set; }
    public float InputY { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }

    public bool KeyDownE { get; private set; }
    public UnityEvent KeyDown_I;

    void Awake()
    {
        InputX = 0f;
        InputY = 0f;
        MouseX = 0f;
        MouseY = 0f;
        KeyDownE = false;
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        KeyDownE = Input.GetKeyDown(KeyCode.E);

        if (Input.GetKeyDown(KeyCode.I))
            KeyDown_I.Invoke();
    }
}