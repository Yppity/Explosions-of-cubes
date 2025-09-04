using System;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 50;
    [SerializeField] private float _explosionRadius = 50;

    public void ExplodeFragments(Cube explodingCube, List<Cube> cubes)
    {
        CalculateScaleExplosion(explodingCube, out float explosionForce, out float explosionRadius);

        if (cubes.Count != 0)
            foreach (Cube cube in cubes)
                if (cube.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddExplosionForce(explosionForce, explodingCube.transform.position, explosionRadius);
    }

    public void ExplodeCube(Cube explodingCube) 
    {
        CalculateScaleExplosion(explodingCube, out float explosionForce, out float explosionRadius);

        foreach (Rigidbody explodableObject in GetExplodableObject(explodingCube)) 
            explodableObject.AddExplosionForce(explosionForce, explodingCube.transform.position, explosionRadius); 
    }

    private List<Rigidbody> GetExplodableObject(Cube explodingCube) 
    { 
        Collider[] hits = Physics.OverlapSphere(explodingCube.transform.position, _explosionRadius); 
        List<Rigidbody> explodableObject = new();
        
        foreach (Collider hit in hits) 
            if (hit.attachedRigidbody != null)
                explodableObject.Add(hit.attachedRigidbody);

        return explodableObject; 
    }

    private void CalculateScaleExplosion(Cube cube, out float explosionForce, out float explosionRadius)
    {
        explosionForce = _explosionForce * (1 / cube.transform.localScale.x);
        explosionRadius = _explosionRadius * (1 / cube.transform.localScale.x);
    }
}
