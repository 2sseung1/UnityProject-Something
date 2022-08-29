using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public Camera RaycastPoint;

    public RaycastHit HitInfo { get { return _hit; } }
    public bool ObjectDetect { get; private set; }

    [SerializeField]
    private float RaycastDistance;

    private RaycastHit _hit;

    public bool ObjectCheck()
    {
        ObjectDetect = Physics.Raycast(RaycastPoint.transform.position, RaycastPoint.transform.forward, out _hit, RaycastDistance);
        return ObjectDetect;
    }
}