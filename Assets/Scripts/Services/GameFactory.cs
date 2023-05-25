using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFactory : IGameFactoryService

{
    private const string Hero = "Prefabs/Cube";
    private const string StartPoint = "Prefabs/StartPoint";

    public GameObject CreatePerson() =>
        Object.Instantiate(ObjectPath(Hero));

    public GameObject CreatePoints() =>
        Object.Instantiate(ObjectPath(StartPoint));

    private static GameObject ObjectPath(string path) =>
        Resources.Load<GameObject>(path);
}

public interface IGameFactoryService : IService
{
    GameObject CreatePoints();
    GameObject CreatePerson();
}
