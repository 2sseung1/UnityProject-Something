using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracte : Interacte
{
    public InventoryController Inventory;

    public override void InteracteObject()
    {
        if (_checker.ObjectCheck())
        {
            var interactionObject = _checker.HitInfo.collider.GetComponent<IInteractionObject>();
            if (interactionObject != null)
                interactionObject.Interacte(transform.position);

            var item = _checker.HitInfo.collider.GetComponent<Item>();
            if (item != null)
                Inventory.ToSlot(item);
        }
    }
}