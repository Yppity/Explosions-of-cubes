using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField] private ActionManager _actionManager;
    [SerializeField] private int _explosionForce = 10;
    [SerializeField] private int _explosionRadius = 100;

    private void OnEnable()
    {
        _actionManager.FragmentableObjectDestroy += Explode;
    }

    private void OnDisable()
    {
        _actionManager.FragmentableObjectDestroy -= Explode;
    }

    public void Explode(List<FragmentableObject> fragmentableObjects)
    {
        if (fragmentableObjects.Count != 0)
            foreach (FragmentableObject fragmentableObject in fragmentableObjects)
                if (fragmentableObject.TryGetComponent(out Rigidbody rigidbody) )
                    rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
