using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PointsList : MonoBehaviour
{
    public List<Transform> listPoints { get; private set; }

    public void InitialPointsList()
    {
        listPoints = new List<Transform>();

        foreach (Transform item in gameObject.transform.GetComponentInChildren<Transform>())
            listPoints.Add(item);
    }
}
