using Cinemachine;
using DG.Tweening;
using UnityEngine;

//[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraMoveTarget : MonoBehaviour
{
    [SerializeField]
    private Transform _pointOnTheSky;
    [SerializeField]
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private Transform _target;


    private void Awake()
    {
        Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out CinemachineBrain brain);
        if (brain == null)
            brain = Camera.main.gameObject.AddComponent<CinemachineBrain>();

    }

    private void Update()
    {
        if (_target == null)
            return;
    }

    public void ObesrveTarget(Transform target)
    {
        _target = target;
        _cinemachineVirtualCamera.LookAt = target;
        _cinemachineVirtualCamera.Follow = target;
    }

    private void Observe()
    {
        var pointObserverTarget = new Vector3(_target.position.x, _target.position.y + 5f, _target.position.z + 5f);
        transform.DOMove(pointObserverTarget, 4f);
    }
}
