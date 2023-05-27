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
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log(22);
                }
            }
        }
    }
    private GameObject SetGameObj(GameObject x = null)
    {
        return x;
    }
}
