using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerRotate _rotate;
    private PlayerMove _move;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rotate = GetComponent<PlayerRotate>();
        _move = GetComponent<PlayerMove>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _rotate.Rotate(_input.MouseX, _input.MouseY);
        _move.Move(_input.InputX, _input.InputY);
    }
}
