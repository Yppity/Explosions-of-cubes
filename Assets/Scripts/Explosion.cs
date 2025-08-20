using System;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 200;
    [SerializeField] private float _explosionRadius = 100;

    public void ExplodeFragments(Cube exploding—ube, List<Cube> cubes)
    {
        CalculateScaleExplosion(exploding—ube, out float explosionForce, out float explosionRadius);

        if (cubes.Count != 0)
            foreach (Cube cube in cubes)
                if (cube.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddExplosionForce(explosionForce, exploding—ube.transform.position, explosionRadius);
    }

    public void ExplodeCube(Cube exploding—ube) 
    {
        CalculateScaleExplosion(exploding—ube, out float explosionForce, out float explosionRadius);

        foreach (Rigidbody explodableObject in GetExplodableObject(exploding—ube)) 
            explodableObject.AddExplosionForce(explosionForce, exploding—ube.transform.position, explosionRadius); 
    }

    private List<Rigidbody> GetExplodableObject(Cube exploding—ube) 
    { 
        Collider[] hits = Physics.OverlapSphere(exploding—ube.transform.position, _explosionRadius); 
        List<Rigidbody> explodableObject = new();
        
        foreach (Collider hit in hits) 
            if (hit.attachedRigidbody != null)
                explodableObject.Add(hit.attachedRigidbody);

        return explodableObject; 
    }

    private void CalculateScaleExplosion(Cube cube, out float explosionForce, out float explosionRadius)
    {
        explosionForce = _explosionForce * cube.transform.localScale.x;
        explosionRadius = _explosionRadius * cube.transform.localScale.x;
    }
}
