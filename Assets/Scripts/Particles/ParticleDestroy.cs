using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    private void Start() => 
        Invoke("Destroy", 5f);

    private void Destroy() => 
        Destroy(gameObject);
}
