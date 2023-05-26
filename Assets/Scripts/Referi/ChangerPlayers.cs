using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(PlayersManager))]
public class ChangerPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject _pointsList;
    private PlayersManager _playersManager;

    private Dictionary<GameObject, Transform> _statusPlayer = new Dictionary<GameObject, Transform>();
    private List<int> _plyerPointPlace = new List<int>();
    private PointsList _pointMove;

    private string _tag;

    private void Awake()
    {
        _playersManager = gameObject.GetComponent<PlayersManager>();
    }
    //Внедряем явную зависимость.
    public void AddPlayer(PlayersManager playerManager, PointsList pointsList)
    {
        InitialPlayersStart();
    }
    //Инициализируем игроков у "рефери"
    private void InitialPlayersStart()
    {
        if (_pointsList.TryGetComponent<PointsList>(out PointsList list))
        {
            _pointMove = list;
            foreach (var player in _playersManager.Players)
            {
                _statusPlayer.Add(player, _pointMove.listPoints[1]);
                _plyerPointPlace.Add(0);
            }
        }
        else return;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OrderToWalk(RollCube.Instance().ThrowCube(), (int)Players.second);
        }
    }
    //Отдаем команду игроку ходить и куда ходить.
    private void OrderToWalk(int throwResult, int player)
    {
        var nextPoint = GetNextPoint(_pointMove, player, throwResult);
        _statusPlayer[_playersManager.Players[player]] = nextPoint;

        _statusPlayer.ElementAt(player).Key.GetComponent<PersonMove>().Move(nextPoint);
    }


    private Transform GetNextPoint(PointsList list, int player, int throwResult)
    {
        _plyerPointPlace[player] += throwResult;

        if (_plyerPointPlace[player] >= _pointMove.listPoints.Count-1)
            _plyerPointPlace[player] = _pointMove.listPoints.Count-1;

        _tag = GetTag(_plyerPointPlace[player]);
        Debug.Log(_tag);

        return list.listPoints[_plyerPointPlace[player]];
    }
    private string GetTag(int throwResult) =>
        _pointMove.listPoints[throwResult].transform.parent.GetChild(throwResult).tag;

    private void RedPoint()
    {

    }

    private void GreenPoint()
    {

    }

    private void NeutralPoint()
    {

    }
}
