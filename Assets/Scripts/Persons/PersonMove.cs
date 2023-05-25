using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    [SerializeField]
    private GetPoints _points;

    private List<Transform> _listPoints;
    private bool isMove;
    private int moveTo;

    private void Awake()
    {
        _points = gameObject.GetComponent<GetPoints>();
        _listPoints = _points.StartPoint.GetComponent<PointsList>().listPoints;
        RollCube.NumberOfMoves += MoveToPoint;
    }

    private void Update()
    {
        if (isMove)
        {
            gameObject.transform.position = _listPoints[moveTo].transform.position;
            isMove = false;
        }
    }

    private int MoveToPoint(int rollCubeResult)
    {
        isMove = true;
        moveTo = rollCubeResult;
        return moveTo;
    }

}
