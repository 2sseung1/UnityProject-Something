using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody MoveTarget;
    public GameObject DirectionTarget;

    [SerializeField]
    private float MoveSpeed;

    private Vector3 _moveDirection;
    private Vector3 _movePosition;

    public void Move(float inputX, float inputY)
    {
        _moveDirection = DirectionTarget.transform.rotation * new Vector3(inputX, 0f, inputY);
        _movePosition = new Vector3(_moveDirection.x, 0f, _moveDirection.z) * MoveSpeed * Time.deltaTime;

        MoveTarget.MovePosition(MoveTarget.position + _movePosition);
    }
}