using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDoorLock : MonoBehaviour
{
    [SerializeField]
    private Door Target;

    void OnTriggerEnter(Collider other)
    {
        Target.DoorState = Door.State.Lock;
        Destroy(gameObject);
    }
}