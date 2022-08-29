using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyFieldOfView))]
public class EnemyAI : MonoBehaviour
{
    public enum SomethingState
    {
        Patrol,
        Tracking
    }

    public Vector3[] PatrolPoint;
    public SomethingState State { get; private set; }

    [SerializeField]
    private int WaitTime;
    [SerializeField]
    private float StoppingDistance;
    [SerializeField]
    private float KillDistance;

    private NavMeshAgent _agent;
    private WaitForFixedUpdate _waitForFixedUpdate;
    private float _remainingDistance;
    private int _index;
    private EnemyFieldOfView _view;
    private GameObject _target;

    void Awake()
    {
        State = SomethingState.Patrol;
        _agent = GetComponent<NavMeshAgent>();
        _waitForFixedUpdate = new WaitForFixedUpdate();
        _view = GetComponent<EnemyFieldOfView>();
    }

    void Start()
    {
        StartCoroutine(SetNextPatrol());
    }

    void Update()
    {
        switch (State)
        {
            case SomethingState.Patrol:
                UpdatePatrol();
                break;

            case SomethingState.Tracking:
                UpdateTracking();
                break;
        }
    }

    void UpdatePatrol()
    {
        if (_view.Search())
        {
            StopAllCoroutines();
            State = SomethingState.Tracking;
            _target = _view.HitInfo.transform.gameObject;
            StartCoroutine(Tracking());
        }
    }

    void UpdateTracking()
    {
        _agent.destination = _target.transform.position;
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            _remainingDistance = (_agent.destination - transform.position).magnitude;
            if (_remainingDistance < StoppingDistance)
            {
                break;
            }

            yield return _waitForFixedUpdate;
        }

        StartCoroutine(SetNextPatrol());
    }

    IEnumerator Tracking()
    {
        Debug.Log("Tracking 시작");

        while (true)
        {
            _remainingDistance = (_agent.destination - transform.position).magnitude;
            if (_remainingDistance < KillDistance)
            {
                break;
            }

            yield return _waitForFixedUpdate;
        }

        Debug.Log("당신은 죽었습니다!");
    }

    IEnumerator SetNextPatrol()
    {
        yield return new WaitForSeconds(WaitTime);

        _index = Random.Range(0, PatrolPoint.Length);
        while (PatrolPoint[_index] == _agent.destination)
        {
            _index = Random.Range(0, PatrolPoint.Length);

            yield return new WaitForSeconds(0.1f);
        }

        _agent.destination = PatrolPoint[_index];
        StartCoroutine(Patrol());
    }
}