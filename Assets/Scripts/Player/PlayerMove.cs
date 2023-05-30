using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(GetStartPoint))]
public class PlayerMove : MonoBehaviour
{
    public bool ReachedPoint { get; set; }

    [SerializeField]
    private GetStartPoint _startPoint;

    private Transform _pointAchive;
    private NavMeshAgent _agent;
    public AnimatorPlayer Animator { get; private set; }

    private bool _isMove;



    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _startPoint = gameObject.GetComponent<GetStartPoint>();
        Animator = GetComponent<AnimatorPlayer>();

        //Варп нужен, чтобы навмеш смог подвязаться, иначе кидал эксепшен
        _agent.Warp(_startPoint.StartPoint.transform.position);

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
