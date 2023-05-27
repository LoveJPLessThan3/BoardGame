using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEditor.Search;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(PlayersManager))]
public class ChangerPlayers : MonoBehaviour
{
    private const string RedPointTag = "RedPoint";
    private const string GreenPointTag = "GreenPoint";
    [SerializeField]
    private GameObject _pointsList;
    private PlayersManager _playersManager;

    private Dictionary<GameObject, Transform> _statusPlayer = new Dictionary<GameObject, Transform>();
    private List<int> _plyerPointPlace = new List<int>();
    private PointsList _pointList;
    private PersonMove _playerHash;

    private string _tag;
    private int _activePlayer;
    private bool _goPoint;

    //Внедряем явную зависимость.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_goPoint)
        {
            _goPoint = true;
            ThrowGameCube();
        }
        if (!_playerHash)
            return;
        else
        {
            if (_playerHash.ReachedPoint)
            {
                if (_goPoint)
                {
                    if (_tag.Equals(RedPointTag))
                        RedPoint(_activePlayer);
                    else if (_tag.Equals(GreenPointTag))
                        GreenPoint(_activePlayer);
                    else if (_tag.Equals("FinishPoint"))
                        FinishPoint(_activePlayer);
                    else NeutralPoint();
                }
            }
        }
    }



    private void ThrowGameCube()
    {
        OrderToWalk(RollCube.Instance().ThrowCube(), _activePlayer);
    }

    public void AddPlayer(PlayersManager playerManager, PointsList pointsList)
    {
        _playersManager = playerManager;
        _pointList = pointsList;
        InitialPlayersStart();
    }
    //Инициализируем игроков у "рефери"
    private void InitialPlayersStart()
    {
        foreach (var player in _playersManager.Players)
        {
            _statusPlayer.Add(player, _pointList.listPoints[1]);
            _plyerPointPlace.Add(0);
        }

        TransferOfPlay();
    }

    private int TransferOfPlay()
    {
        foreach (var player in _statusPlayer)
        {
            player.Key.GetComponent<PersonMove>().enabled = false;
        }
        _statusPlayer.ElementAt(_activePlayer).Key.GetComponent<PersonMove>().enabled = true;
        return _activePlayer;

    }
    private void ChangeActivePlayer()
    {
        _activePlayer++;
        if (_activePlayer > _playersManager.Players.Count - 1)
            _activePlayer = 0;
    }
    //Отдаем команду игроку ходить и куда ходить.
    private void OrderToWalk(int throwResult, int player)
    {
        MoveNextPoint(throwResult, player);

        //Кэшируем плээера, чтобы затем взять у него свойство достижения клетки
        _playerHash = _statusPlayer.ElementAt(player).Key.GetComponent<PersonMove>();
        _playerHash.ReachedPoint = false; //переделать
    }

    private void MoveNextPoint(int throwResult, int player)
    {
        _goPoint = true;
        Transform nextPoint = GetNextPoint(throwResult, player);

        Debug.Log(player + " " + nextPoint);
        _statusPlayer.ElementAt(player).Key.GetComponent<PersonMove>().Move(nextPoint);
    }

    private Transform GetNextPoint(int throwResult, int player)
    {
        var nextPoint = InitialNextPoint(_pointList, player, throwResult);
        _statusPlayer[_playersManager.Players[player]] = nextPoint;
        return nextPoint;
    }

    private Transform InitialNextPoint(PointsList list, int player, int throwResult)
    {
        _plyerPointPlace[player] += throwResult;

        if (_plyerPointPlace[player] >= _pointList.listPoints.Count - 1)
            _plyerPointPlace[player] = _pointList.listPoints.Count - 1;

        _tag = GetTag(_plyerPointPlace[player]);

        return list.listPoints[_plyerPointPlace[player]];
    }
    private string GetTag(int throwResult) =>
        _pointList.listPoints[throwResult].transform.parent.GetChild(throwResult).tag;

    private void RedPoint(int player)
    {
        _goPoint = false;
        MoveNextPoint(-3, player);
    }


    private void GreenPoint(int player)
    {
        _goPoint = false;
        ThrowGameCube();
    }

    private void FinishPoint(int activePlayer)
    {
       // _statusPlayer.Remove(_statusPlayer.ElementAt(activePlayer).Key);
    }

    private void NeutralPoint()
    {
        ActiveNextPlayer();
    }
    private void ActiveNextPlayer()
    {
        _goPoint = false;
        _playerHash = null;
        ChangeActivePlayer();
        TransferOfPlay();
    }
}
