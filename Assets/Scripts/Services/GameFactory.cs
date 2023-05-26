using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameFactory : IGameFactoryService
{
    public static event Action CreatedObjects;
    public List<GameObject> ListPlayers { get; set; }


    private const string Hero = "Prefabs/Cube";
    private const string Hero1 = "Prefabs/Sphere";
    private const string StartPoint = "Prefabs/StartPoint";


    public GameObject CreatePerson() =>
        Object.Instantiate(ObjectPath(Hero));

    public GameObject CreatePoints() =>
        Object.Instantiate(ObjectPath(StartPoint));

    public List<GameObject> CreatePlayers(int playersValue)
    {
        ListPlayers = new List<GameObject>();

        ListPlayers.Add(Object.Instantiate(ObjectPath(Hero)));
        ListPlayers.Add(Object.Instantiate(ObjectPath(Hero1)));


        CreatedObjects?.Invoke();

        return ListPlayers;
    }

    private static GameObject ObjectPath(string path) =>
        Resources.Load<GameObject>(path);

}

public interface IGameFactoryService : IService
{
    GameObject CreatePoints();
    GameObject CreatePerson();
    List<GameObject> CreatePlayers(int playersValue);
    List<GameObject> ListPlayers { get; set; }
}
