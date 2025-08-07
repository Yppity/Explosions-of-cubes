using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FragmentableObject : MonoBehaviour
{
    [SerializeField] private int _chanceFragmentation = 100;

    public int GetChanceFragmentation()
    {
        return _chanceFragmentation;
    }

    public void Initialized(int chanceFragmentation, Vector3 scale)
    {
        _chanceFragmentation = chanceFragmentation;
        transform.localScale = scale;
    }
}
