using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public Camera RaycastPoint;
    public InventoryController InventoryController;

    public bool Collision { get; private set; }
    public RaycastHit HitTargetInfo { get { return _hit; } }

    [SerializeField]
    private float RaycastDistance;

    private RaycastHit _hit;

    public void ObjectCheck()
    {
        Collision = Physics.Raycast(RaycastPoint.transform.position, RaycastPoint.transform.forward, out _hit, RaycastDistance);
    }
}