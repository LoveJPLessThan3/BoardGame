using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(GetStartPoint))]
public class PlayerMove : MonoBehaviour                      //Плээер не знает куда ему ходить, до того момента, пока ему не сообщат.
{
    public AnimatorPlayer Animator { get; private set; }

    public bool ReachedPoint { get; set; }

    [SerializeField]
    private GetStartPoint _startPoint;

    private Transform _pointAchive;
    private NavMeshAgent _agent;
   
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _startPoint = gameObject.GetComponent<GetStartPoint>();
        Animator = GetComponent<AnimatorPlayer>();

        //Варп нужен, чтобы навмеш смог подвязаться, иначе кидал эксепшен
        _agent.Warp(_startPoint.StartPoint.transform.position);

    }

    private void Update()
    {
        if(_pointAchive != null)
        {
            _agent.SetDestination(_pointAchive.position);
            ReachedPoint = DistanceToPoint();
        }
    }

    public Transform Move(Transform nextPoint) =>
        _pointAchive = nextPoint;

    public bool DistanceToPoint()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {

                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _agent.ResetPath();
                    return true;
                }
            }
        }
        return false;
    }
}
