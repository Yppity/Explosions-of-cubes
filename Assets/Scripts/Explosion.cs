using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private EventHub _eventHub;
    [SerializeField] private int _explosionForce = 10;
    [SerializeField] private int _explosionRadius = 100;

    private void OnEnable()
    {
        _eventHub.CubeDestroy += Explode;
    }

    private void OnDisable()
    {
        _eventHub.CubeDestroy -= Explode;
    }

    public void Explode(List<Cube> cubes)
    {
        if (cubes.Count != 0)
            foreach (Cube cube in cubes)
                if (cube.TryGetComponent(out Rigidbody rigidbody) )
                    rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
