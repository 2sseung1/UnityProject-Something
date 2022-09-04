using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractionObject
{
    public enum State
    {
        Open,
        Close,
        Lock
    }

    public State GetDoorState { get { return DoorState; } }

    public State DoorState;
    [SerializeField]
    private float RotateSpeed;
    [SerializeField]
    private DoorData _data;

    private float _angleY;
    private float _initialAngleY;
    private float _openForwardMinAngleY;
    private float _openBackwardMaxAngleY;
    private WaitForFixedUpdate _waitForFixedUpdate;
    private AudioSource _audio;

    void Awake()
    {
        _angleY = transform.eulerAngles.y;
        _initialAngleY = _angleY;
        _openForwardMinAngleY = _angleY - 90;
        _openBackwardMaxAngleY = _angleY + 90;
        _waitForFixedUpdate = new WaitForFixedUpdate();
        _audio = GetComponent<AudioSource>();
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
                _audio.clip = _data.OpenSound;
                _audio.Play();
                break;

            case State.Lock:
                _audio.clip = _data.LockSound;
                _audio.Play();
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

        _audio.clip = _data.CloseSound;
        _audio.Play();
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

        _audio.clip = _data.CloseSound;
        _audio.Play();
    }
}