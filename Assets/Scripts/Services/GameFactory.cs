using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameFactory : IGameFactoryService
{
    public static event Action CreatedObjects;
    public List<GameObject> ListPlayers { get; set; }

    private IStaticDataService _staticDataService;

    public GameFactory(IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    private const string Hero = "Prefabs/Cube";
    private const string Hero1 = "Prefabs/Sphere";
    private const string StartPoint = "Prefabs/StartPoint";


    public GameObject CreatePerson() =>
        Object.Instantiate(ObjectPath(Hero));

    private GameObject CreatePlayer(Players player)
    {
        StaticDataPlayers staticDataPlayer = _staticDataService.ForPlayer(player);
        return Object.Instantiate(staticDataPlayer.Prefab);
    }

    public GameObject CreatePoints() =>
        Object.Instantiate(ObjectPath(StartPoint));

    //научить передавать иконку
    public List<GameObject> CreatePlayers(int playersValue)
    {
        ListPlayers = new List<GameObject>();

        ListPlayers.Add(CreatePlayer(Players.First));
        ListPlayers.Add(CreatePlayer(Players.Second));


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
