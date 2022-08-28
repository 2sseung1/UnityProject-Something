using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SomethingController : MonoBehaviour
{
    public enum SomethingState
    {
        Patrol
    }

    public Vector3[] PatrolPoint;
    public SomethingState State { get; private set; }

    [SerializeField]
    private int WaitTime;
    [SerializeField]
    private float StoppingDistance;

    private NavMeshAgent _agent;
    private WaitForFixedUpdate _waitForFixedUpdate;
    private float _remainingDistance;
    private int _index;

    void Awake()
    {
        State = SomethingState.Patrol;
        _agent = GetComponent<NavMeshAgent>();
        _waitForFixedUpdate = new WaitForFixedUpdate();
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
        }
    }

    void UpdatePatrol()
    {

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