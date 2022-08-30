using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractionObject
{
    public enum State
    {
        Open,
        Close
    }

    public State GetDoorState { get { return DoorState; } }

    [SerializeField]
    private State DoorState;
    [SerializeField]
    private float RotateSpeed;

    private float _angleY;
    private float _initialAngleY;
    private float _openForwardMinAngleY;
    private float _openBackwardMaxAngleY;
    private WaitForFixedUpdate _waitForFixedUpdate;
    private DoorData _data;

    void Awake()
    {
        _angleY = transform.eulerAngles.y;
        _initialAngleY = _angleY;
        _openForwardMinAngleY = _angleY - 90;
        _openBackwardMaxAngleY = _angleY + 90;
        _waitForFixedUpdate = new WaitForFixedUpdate();
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
        StopAllCoroutines();
        DoorState = State.Open;

        Vector3 toInteractor = (interactorPosition - transform.position).normalized;
        if (0 <= Vector3.Dot(transform.forward, toInteractor))
            StartCoroutine(OpenForward());
        else
            StartCoroutine(OpenBackward());
    }

    IEnumerator OpenForward()
    {
        while (_openForwardMinAngleY <= _angleY)
        {
            _angleY -= RotateSpeed * Time.fixedDeltaTime;
            Vector3 newRotation = new Vector3(0f, _angleY, 0f);
            transform.rotation = Quaternion.Euler(newRotation);

            yield return _waitForFixedUpdate;
        }
    }

    IEnumerator OpenBackward()
    {
        while (_angleY < _openBackwardMaxAngleY)
        {
            _angleY += RotateSpeed * Time.fixedDeltaTime;
            Vector3 newRotation = new Vector3(0f, _angleY, 0f);
            transform.rotation = Quaternion.Euler(newRotation);

            yield return _waitForFixedUpdate;
        }
    }

    private void Close()
    {
        StopAllCoroutines();
        DoorState = State.Close;

        if (_angleY <= _initialAngleY)
            StartCoroutine(CloseBackward());
        else
            StartCoroutine(CloseForward());
    }

    IEnumerator CloseForward()
    {
        while (_initialAngleY < _angleY)
        {
            _angleY -= RotateSpeed * Time.fixedDeltaTime;
            Vector3 newRotation = new Vector3(0f, _angleY, 0f);
            transform.rotation = Quaternion.Euler(newRotation);

            yield return _waitForFixedUpdate;
        }
    }

    IEnumerator CloseBackward()
    {
        while (_angleY <= _initialAngleY)
        {
            _angleY += RotateSpeed * Time.fixedDeltaTime;
            Vector3 newRotation = new Vector3(0f, _angleY, 0f);
            transform.rotation = Quaternion.Euler(newRotation);

            yield return _waitForFixedUpdate;
        }
    }
}