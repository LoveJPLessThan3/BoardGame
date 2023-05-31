using System;
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

    private const string StartPoint = "Prefabs/StartPoint";

    private GameObject CreatePlayer(Players player)
    {
        StaticDataPlayers staticDataPlayer = _staticDataService.ForPlayer(player);
        return Object.Instantiate(staticDataPlayer.Prefab);
    }

    public GameObject CreatePoints() =>
        Object.Instantiate(ObjectPath(StartPoint));

    //������� ���������� ������
    public List<GameObject> CreatePlayers(int playersValue)
    {
        ListPlayers = new List<GameObject>();

        for (int player = 0; player < playersValue; player++)
        {
            ListPlayers.Add(CreatePlayer(player.CompareWithEnum()));

        }

        //�������� PlayerManager, ����� ������, ����� ������� �����������������
        CreatedObjects?.Invoke();

        return ListPlayers;
    }

    private static GameObject ObjectPath(string path) =>
        Resources.Load<GameObject>(path);

}
