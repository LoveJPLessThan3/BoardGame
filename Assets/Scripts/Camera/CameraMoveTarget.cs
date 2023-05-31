using Cinemachine;
using UnityEngine;

public class CameraMoveTarget : MonoBehaviour
{
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
}
