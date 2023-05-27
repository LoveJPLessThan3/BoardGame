using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(GetPoints))]
public class PersonMove : MonoBehaviour
{
    public bool ReachedPoint { get; set; }

    [SerializeField]
    private GetPoints _points;

    private NavMeshAgent _agent;
    private bool _isMove;
    private Transform _pointAchive;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _points = gameObject.GetComponent<GetPoints>();

        //Варп нужен, чтобы навмеш смог подвязаться, иначе кидал эксепшен
        _agent.Warp(_points.StartPoint.transform.position);

    }

    private void Update()
    {
        if(_pointAchive != null)
        {
            _agent.SetDestination(_pointAchive.position);
            ReachedPoint = DistanceToPoint();
        }
    }

    public Transform Move(Transform nextPoint)
    {
        return _pointAchive = nextPoint;
    }
    public bool DistanceToPoint()
    {
        //return Vector3.Distance(_pointAchive.position, gameObject.transform.position) < 0.5f;
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {

                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _agent.ResetPath();
                    return true;
                }
            }
        }
        return false;
    }
}
