using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public Camera RaycastPoint;

    public RaycastHit HitInfo { get { return _hit; } }

    [SerializeField]
    private float RaycastDistance;

    private RaycastHit _hit;

    public bool ObjectCheck()
    {
        return Physics.Raycast(RaycastPoint.transform.position, RaycastPoint.transform.forward, out _hit, RaycastDistance);
    }
}