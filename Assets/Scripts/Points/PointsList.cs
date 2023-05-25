using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PointsList : MonoBehaviour
{
    public List<Transform> listPoints { get; private set; } 
    private void Awake()
    {
        InitialPointsList();
    }

    private void InitialPointsList()
    {
        listPoints = new List<Transform>();

        foreach (Transform item in gameObject.transform.GetComponentInChildren<Transform>())
            listPoints.Add(item);


        Debug.Log(listPoints[2]);
       // listPoints.Sort();
    }
}
