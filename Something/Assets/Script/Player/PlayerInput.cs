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

    public UnityEvent InteractionKeyDown;
    public UnityEvent EscapeKeyDown;
    public UnityEvent<KeyCode> UIKeyDown;

    [SerializeField]
    private UIManager UIManager;

    void Awake()
    {
        InputX = 0f;
        InputY = 0f;
        MouseX = 0f;
        MouseY = 0f;

        UIKeyDown.AddListener(UIManager.MenuControl);
    }

    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionKeyDown.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UIKeyDown.Invoke(KeyCode.I);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeKeyDown.Invoke();
        }
    }
}