using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject InteractTarget;

    void OnTriggerEnter(Collider other)
    {
        IInteractionObject target = InteractTarget.GetComponent<IInteractionObject>();
        target.Interacte(transform.position);
        GameObject.Destroy(gameObject);
    }
}