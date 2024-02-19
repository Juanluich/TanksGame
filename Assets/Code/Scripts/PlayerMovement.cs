using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent _agent;
    public bool myTurn = false;

    private Vector3 auxDestination;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && myTurn)
        {
            //if (EventSystem.current.IsPointerOverGameObject())
            //{
            //    return;
            //}
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            {
                var randomOffset = Random.insideUnitSphere * 0.5f;
                randomOffset.y = 0;
                _agent.destination = hitInfo.point + randomOffset;
                auxDestination = _agent.destination;
                //myTurn = false;
            }
        }

    }
}
