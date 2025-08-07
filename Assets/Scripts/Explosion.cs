using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _explosionForce = 10;
    [SerializeField] private int _explosionRadius = 100;

    private void OnEnable()
    {
        _spawner.FragmentableObjectDestroy += Explode;
    }

    private void OnDisable()
    {
        _spawner.FragmentableObjectDestroy -= Explode;
    }

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObject(_explosionRadius))
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObject(float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> explodableObject = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explodableObject.Add(hit.attachedRigidbody);

        return explodableObject;
    }
}
