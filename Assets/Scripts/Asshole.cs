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
    }

    void Update()
    {
        //The agent heads to the next spot in a loop, once it has reached its destination it goes to the next one
        _agent.SetDestination(destinations[destinationCounter].localPosition);
        // Debug.Log("Local");
        // Debug.Log(transform.localPosition);
        // Debug.Log("Destination");
        // Debug.Log(destinations[destinationCounter].localPosition);
        if(_agent.remainingDistance == 0)
        {
            destinationCounter++;
            destinationCounter = destinationCounter%destinations.Count();
            // Debug.Log(destinationCounter);
        }
    }
}
