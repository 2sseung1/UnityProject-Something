using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractionObject
{
    private enum State
    {
        Open,
        Close
    }

    [SerializeField]
    private State DoorState;

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interacte(Vector3 interactorPosition)
    {
        switch (DoorState)
        {
            case State.Open:
                Close();
                break;

            case State.Close:
                Open(interactorPosition);
                break;
        }
    }

    private void Open(Vector3 interactorPosition)
    {
        DoorState = State.Open;
        _animator.SetInteger("State", (int)DoorState);

        Vector3 toInteractor = (interactorPosition - transform.position).normalized;
        if (0 <= Vector3.Dot(transform.forward, toInteractor))
        {
            _animator.SetInteger("Direction", 1);
        }
        else
        {
            _animator.SetInteger("Direction", -1);
        }
    }

    private void Close()
    {
        DoorState = State.Close;
        _animator.SetInteger("State", (int)DoorState);
        _animator.SetInteger("Direction", 0);
    }
}