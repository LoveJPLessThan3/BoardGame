using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StaticData/PlayerStaticData", menuName = "PlayerStaticData")]
public class StaticDataPlayers : ScriptableObject
{
    public Players playerId;

    public string Name;
    public Sprite Icon;
    public GameObject Prefab;
}
