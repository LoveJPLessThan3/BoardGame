using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    private NavMeshAgent _agent;
    public Transform gameobj;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();  
    }

    private void Update()
    {
        _agent.SetDestination(gameobj.position);

    }
}
