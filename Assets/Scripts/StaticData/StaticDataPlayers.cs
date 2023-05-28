using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StaticData/PlayerStaticData", menuName = "PlayerStaticData")]
public class StaticDataPlayers : ScriptableObject
{
    [Range(1, 4)]
    public int id;

    public string Name;
    public Sprite Icon;
}
