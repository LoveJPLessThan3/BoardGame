using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoints : MonoBehaviour
{
    public GameObject StartPoint { get; private set; }
    public void Awake()
    {
        StartPoint = GameObject.FindGameObjectWithTag("StartPoint");
        transform.position = StartPoint.transform.position;
    }
}
