using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private Dictionary<Players, StaticDataPlayers> _players;

    public void LoadPlayers()
    {
        _players = Resources.LoadAll<StaticDataPlayers>("PlayerInfoStaticData")
            .ToDictionary(x => x.playerId, x => x);
    }

    public StaticDataPlayers ForPlayer(Players playersId) =>
        _players.TryGetValue(playersId, out StaticDataPlayers staticData) ? staticData : null;
}
