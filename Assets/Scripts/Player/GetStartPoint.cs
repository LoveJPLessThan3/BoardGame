using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStartPoint : MonoBehaviour
{
    private const string StartPointTag = "StartPoint";

    public GameObject StartPoint { get; private set; }

    public void Awake()
    {
        StartPoint = GameObject.FindGameObjectWithTag(StartPointTag);
        var position = new Vector3(StartPoint.transform.position.x, StartPoint.transform.position.y, StartPoint.transform.position.z);
        transform.position = position;
    }
}
