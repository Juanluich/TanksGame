using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent _agent;

    [SerializeField] float _radius;
    [SerializeField] Transform[] navigablePlaces;

    public bool aiTurn;
    private Vector3 _auxDestination;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        aiTurn = true;
    }
    private void Update()
    {
        if (aiTurn)
        {
            MoveToRandomPosition();
            aiTurn = false;
        }
        if (!aiTurn && Vector3.Distance(transform.position, _auxDestination) <= .5f)
        {
            _auxDestination = Vector3.up * 100;
        }
    }
    void MoveToRandomPosition()
    {
        Vector3 randomPos = RandomNavMeshLocation(_radius);
        _auxDestination = randomPos;
        _agent.SetDestination(randomPos);
    }

    Vector3 RandomNavMeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        int randomPos = Random.Range(0, navigablePlaces.Length);
        randomDirection += navigablePlaces[randomPos].position;
        NavMeshHit hit;
        if (randomDirection.y > 0) { RandomNavMeshLocation(radius); }
        NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas);

        return hit.position;
    }
    public bool DestinationReached()
    {
        return Vector3.Distance(transform.position, _auxDestination) <= .5f;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for(int i = 0; i < navigablePlaces.Length; i++)
        {
            Gizmos.DrawWireSphere(navigablePlaces[i].position, _radius);

        }
    }
}
