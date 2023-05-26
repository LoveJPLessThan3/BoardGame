using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

//Переделать
public class RollCube : MonoBehaviour
{
    //public static event Func<int,int> NumberOfMoves;

    private static RollCube _instantiate;
    private Random random = new Random();

    private void Awake()
    {
        Instance();
    }


    public static RollCube Instance() 
        => _instantiate ?? (_instantiate = new RollCube());

    public int ThrowCube() => 
        random.RandomInt(1, 6);
}


public static class ExtentionRange
{
    public static int RandomInt(this Random random, int x, int y)
    {
        return random.Next(x-1, y);
    }
}
