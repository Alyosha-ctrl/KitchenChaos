using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Asshole : MonoBehaviour
{
    private NavMeshAgent _agent;
    public List<Transform> destinations;
    int destinationCounter = 0;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(destinations[destinationCounter].localPosition);
    }

    void Update()
    {
        //The agent heads to the next spot in a loop, once it has reached its destination it goes to the next one
        // Debug.Log("Local");
        // Debug.Log(transform.localPosition);
        // Debug.Log("Destination");
        // Debug.Log(destinations[destinationCounter].localPosition);
        if(_agent.remainingDistance <= _agent.stoppingDistance)
        {
            Debug.Log(destinationCounter);
            destinationCounter++;
            destinationCounter = destinationCounter%destinations.Count();
            _agent.SetDestination(destinations[destinationCounter].localPosition);
        }
    }
}
