using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Camera RaycastPoint;

    [SerializeField]
    private float RaycastDistance;

    private RaycastHit _hit;

    public void ObjectCheck(bool keyDownE)
    {
        if (Physics.Raycast(RaycastPoint.transform.position, RaycastPoint.transform.forward, out _hit, RaycastDistance))
        {
            var hitObject = _hit.collider.GetComponent<IInteractionObject>();

            if (keyDownE && hitObject != null)
            {
                hitObject.Interacte();
            }
        }
    }
}