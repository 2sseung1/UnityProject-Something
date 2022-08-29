using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    public RaycastHit HitInfo { get { return _hitInfo; } }

    [SerializeField]
    private float ViewRadius;
    [SerializeField]
    [Range(0, 360)]
    private float ViewAngle;

    private LayerMask _playerLayerMask;
    private Collider[] _colliders;
    private RaycastHit _hitInfo;

    void Awake()
    {
        _playerLayerMask = LayerMask.NameToLayer("Player");
    }

    public bool Search()
    {
        _colliders = Physics.OverlapSphere(transform.position, ViewRadius, 1 << _playerLayerMask);
        if (0 < _colliders.Length)
        {
            Vector3 direction = (_colliders[0].transform.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, direction);
            if (angle < (ViewAngle / 2))
            {
                if (Physics.Raycast(transform.position, direction, out _hitInfo, ViewRadius))
                {
                    if (HitInfo.collider.tag == "Player")
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}