using System.Collections.Generic;
using UnityEngine;

public interface IGameFactoryService : IService
{
    GameObject CreatePoints();
    List<GameObject> CreatePlayers(int playersValue);
    List<GameObject> ListPlayers { get; set; }
}
