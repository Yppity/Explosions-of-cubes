using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ActionManager _actionManager;

    public event Action<List<FragmentableObject>> FragmentableObjectDestroy;

    private void OnEnable()
    {
        _actionManager.FragmentableObjectHit += FragmentationObject;
    }

    private void OnDisable()
    {
        _actionManager.FragmentableObjectHit -= FragmentationObject;
    }

    private void FragmentationObject(FragmentableObject fragmentableObject)
    {
        int multiplierSizeFragments = 2;
        int fragmentationChanceReductionMultiplier = 2;
        int minFragmentation = 2;
        int maxFragmentation = 7;
        int percentageMultiplier = 101;
        List<FragmentableObject> newFragmentableObjects = new List<FragmentableObject>();

        int chanceSuccessfulFragmentation = UnityEngine.Random.Range(0, percentageMultiplier);

        if (chanceSuccessfulFragmentation <= fragmentableObject.GetChanceFragmentation())
        {
            Vector3 scale = fragmentableObject.transform.localScale / multiplierSizeFragments;
            int chanceFragmentation = fragmentableObject.GetChanceFragmentation() / fragmentationChanceReductionMultiplier;

            int numberFragmentations = UnityEngine.Random.Range(minFragmentation, maxFragmentation);

            for (int i = 0; i < numberFragmentations; i++)
            {
                fragmentableObject.Initialized(chanceFragmentation, scale);
                FragmentableObject newFragmentableObject = Instantiate(fragmentableObject);
                newFragmentableObjects.Add(newFragmentableObject);
            }
        }

        DestroyFragmentableObject(fragmentableObject, newFragmentableObjects);
    }

    private void DestroyFragmentableObject(FragmentableObject fragmentableObject, List<FragmentableObject> fragmentableObjects)
    {
        Destroy(fragmentableObject.gameObject);
        FragmentableObjectDestroy?.Invoke(fragmentableObjects);
    }
}
