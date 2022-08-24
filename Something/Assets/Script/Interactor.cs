using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectChecker))]
public class Interactor : MonoBehaviour
{
    public InventoryController InventoryController;

    private ObjectChecker _checker;

    void Awake()
    {
        _checker = GetComponent<ObjectChecker>();
    }

    public void InteracteObject()
    {
        if (_checker.Collision)
        {
            var interactionObject = _checker.HitTargetInfo.collider.GetComponent<IInteractionObject>();
            if (interactionObject != null)
                interactionObject.Interacte(transform.position);

            var item = _checker.HitTargetInfo.collider.GetComponent<Item>();
            if (item != null)
                InventoryController.ToSlot(item);
        }
    }
}