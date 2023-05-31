using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _firstParticle;
    [SerializeField]
    private ParticleSystem _secondParticle;
    [SerializeField]
    private GameObject _crown;

    public void FinishReached()
    {
        _firstParticle.gameObject.SetActive(true);
        _secondParticle.gameObject.SetActive(true);
    }
}
