using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFactory : IGameFactoryService

{
    private const string Hero = "Prefabs/Cube";

    public GameObject CreatePerson()
    {
        return Object.Instantiate(ObjectPath());
    }
    private static GameObject ObjectPath()
    {
        return Resources.Load<GameObject>(Hero);
    }
}

public interface IGameFactoryService : IService
{
    GameObject CreatePerson();
}
