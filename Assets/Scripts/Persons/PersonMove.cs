using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(GetPoints))]
public class PersonMove : MonoBehaviour
{
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
        if (_isMove)
        {
            _agent.SetDestination(_pointAchive.position);
        }

    }



    //private float DistanceToPoint()
    //{
    //    return Vector3.Distance(_listPoints[_moveTo].position, gameObject.transform.position);
    //}


    public Transform Move(Transform nextPoint)
    {
        _isMove = true;
        return _pointAchive = nextPoint;
    }
}
