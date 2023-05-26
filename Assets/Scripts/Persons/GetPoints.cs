using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoints : MonoBehaviour
{
    public GameObject StartPoint { get; private set; }
    public void Awake()
    {
        StartPoint = GameObject.FindGameObjectWithTag("StartPoint");
        var position = new Vector3(StartPoint.transform.position.x, StartPoint.transform.position.y, StartPoint.transform.position.z);
        transform.position = position;
    }
}
