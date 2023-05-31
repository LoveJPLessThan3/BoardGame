using UnityEngine;
using Random = System.Random;

public class RollCube : MonoBehaviour
{
    private static RollCube _instantiate;
    private Random random = new Random();

    private void Awake() => 
        Instance();

    public static RollCube Instance() 
        => _instantiate ?? (_instantiate = new RollCube());

    public int ThrowCube() => 
        random.RandomInt(1, 6);
}
