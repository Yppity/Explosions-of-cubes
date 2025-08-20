using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceFragmentation = 100;

    public int ChanceFragmentation => _chanceFragmentation;

    public void Initialize(int chanceFragmentation, Vector3 scale)
    {
        _chanceFragmentation = chanceFragmentation;
        transform.localScale = scale;
    }
}
