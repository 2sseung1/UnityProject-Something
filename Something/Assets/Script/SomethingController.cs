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
    private float _remainingDistance;

    public Vector3 temp;
    public int index;

    void Awake()
    {
        State = SomethingState.Patrol;
        _agent = GetComponent<NavMeshAgent>();
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
        Debug.Log("순찰 시작");

        while (true)
        {
            _remainingDistance = (_agent.destination - transform.position).magnitude;
            if (_remainingDistance < StoppingDistance)
            {
                break;
            }

            yield return new WaitForFixedUpdate();
        }

        StartCoroutine(SetNextPatrol());
    }

    IEnumerator SetNextPatrol()
    {
        Debug.Log("목적지 설정중");
        yield return new WaitForSeconds(WaitTime);

        index = Random.Range(0, PatrolPoint.Length);
        while (PatrolPoint[index] == _agent.destination)
        {
            index = Random.Range(0, PatrolPoint.Length);
            temp = PatrolPoint[index];

            yield return new WaitForSeconds(0.1f);
        }

        _agent.destination = PatrolPoint[index];
        StartCoroutine(Patrol());
    }
}