using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Numerics;
using UnityEditor.Search;
using UnityEngine;

[RequireComponent(typeof(PlayersManager))]
public class ChangerPlayers : MonoBehaviour
{

    public static event Action<StaticDataPlayers> PlayerIsActive;

    private const string RedPointTag = "RedPoint";
    private const string GreenPointTag = "GreenPoint";
    private const string FinishPointTag = "FinishPoint";

    [SerializeField]
    private GameObject _pointsList;
    [SerializeField]
    private CameraMoveTarget _cameraMoveTarget;
    [SerializeField]
    private ParticleSystem _particleRed;
    [SerializeField]
    private ParticleSystem _particleGreen;
    [SerializeField]
    private ParticleSystem _particleWin;

    private PlayersManager _playersManager;
    private FinishHandler _finishHandler;
    private IStaticDataService _staticDataPlayer;

    private Dictionary<GameObject, Transform> _statusPlayer = new Dictionary<GameObject, Transform>();
    private List<int> _plyerPointPlace = new List<int>();
    private PointsList _pointList;
    private PlayerMove _playerHash;
    private Transform _nextPoint;

    private string _tag;
    private int _activePlayer;
    private bool _goPoint;
    private bool _flag;

    private void Awake()
    {
        _staticDataPlayer = ServiceLocator.Instantiate.GetService<IStaticDataService>();
        WalkerContainer.SaidThrowGameCubeForReferee += ThrowGameCube;

        _finishHandler = GetComponent<FinishHandler>();
    }

    private void LateUpdate()
    {
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
                    else if (_tag.Equals(FinishPointTag))
                        FinishPoint(_activePlayer);
                    else NeutralPoint();

                }
            }
        }
    }

    private void OnDestroy()
    {
        WalkerContainer.SaidThrowGameCubeForReferee -= ThrowGameCube;
    }

    private void ThrowGameCube()
    {
        _goPoint = true;
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
        SendDataPlayer();
    }

    private int TransferOfPlay()
    {
        foreach (var player in _statusPlayer)
        {
            player.Key.GetComponent<PlayerMove>().enabled = false;
        }
        _statusPlayer.ElementAt(_activePlayer).Key.GetComponent<PlayerMove>().enabled = true;
        _playerHash = _statusPlayer.ElementAt(_activePlayer).Key.GetComponent<PlayerMove>();

        _cameraMoveTarget.ObesrveTarget(_playerHash.transform);

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
    }

    private void MoveNextPoint(int throwResult, int player)
    {
        _nextPoint = GetNextPoint(throwResult, player);
        _flag = true;

        _playerHash.Animator.PlayWalk();
        _cameraMoveTarget.ObesrveTarget(_playerHash.transform);

        _goPoint = true;
        _playerHash.Move(_nextPoint);
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
        Instantiate(_particleRed, ParticlePlace(), ParticleRotate());
        _goPoint = false;
        MoveNextPoint(-3, player);
    }

    private void GreenPoint(int player)
    {

        Instantiate(_particleGreen, ParticlePlace(), ParticleRotate());
        _goPoint = false;
        ThrowGameCube();
    }

    private Quaternion ParticleRotate() =>
        Quaternion.Euler(_nextPoint.rotation.x, -_nextPoint.rotation.y, _nextPoint.rotation.z);

    private Vector3 ParticlePlace() => 
        new Vector3(_nextPoint.transform.position.x, _nextPoint.transform.position.y + 3f, _nextPoint.transform.position.z);

    private void FinishPoint(int activePlayer)
    {
        _finishHandler.FinishReached();
        _playerHash.Animator.PlayWin();
    }

    private void NeutralPoint()
    {
        ActiveNextPlayer();
    }
    private void ActiveNextPlayer()
    {
        //не доходит
        _playerHash.Animator.PlayIdle();
        _goPoint = false;
        _playerHash = null;
        ChangeActivePlayer();
        SendDataPlayer();

        TransferOfPlay();
    }

    private void SendDataPlayer()
    {
        StaticDataPlayers player = _staticDataPlayer.ForPlayer(_activePlayer.CompareWithEnum());
        PlayerIsActive?.Invoke(player);
    }
}




public static class ExtensionCompareIntAndEnum
{
    public static Players CompareWithEnum(this int value)
    {
        return (Players)value;
    }
}