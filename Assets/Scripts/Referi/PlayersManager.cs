using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public List<GameObject> Players { get; private set; }

    [SerializeField]
    private PointsList _pointList;
    private ChangerPlayers _changerPlayers;
    

    private void Awake()
    {
        GameFactory.CreatedObjects += CreatedPlayers;
        _changerPlayers = gameObject.GetComponent<ChangerPlayers>();

    }

    private void CreatedPlayers()
    {
        var playersList = ServiceLocator.Instantiate.GetService<IGameFactoryService>().ListPlayers;
        _pointList.InitialPointsList();

        Players = new List<GameObject>();
        Players.AddRange(playersList);

        _changerPlayers.AddPlayer(this, _pointList);
    }


}
