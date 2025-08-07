using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    public event Action FragmentableObjectDestroy;

    private void OnEnable()
    {
        _raycaster.FragmentableObjectHit += FragmentationObject;
    }

    private void OnDisable()
    {
        _raycaster.FragmentableObjectHit -= FragmentationObject;
    }

    private void FragmentationObject(FragmentableObject fragmentableObject)
    {
        int multiplierSizeFragments = 2;
        int fragmentationChanceReductionMultiplier = 2;
        int minFragmentation = 2;
        int maxFragmentation = 7;
        int percentageMultiplier = 101;

        int chanceSuccessfulFragmentation = UnityEngine.Random.Range(0, percentageMultiplier);

        if (chanceSuccessfulFragmentation <= fragmentableObject.GetChanceFragmentation())
        {
            Vector3 scale = fragmentableObject.transform.localScale / multiplierSizeFragments;
            int chanceFragmentation = fragmentableObject.GetChanceFragmentation() / fragmentationChanceReductionMultiplier;

            int numberFragmentations = UnityEngine.Random.Range(minFragmentation, maxFragmentation);

            for (int i = 0; i < numberFragmentations; i++)
            {
                fragmentableObject.Initialized(chanceFragmentation, scale);
                Instantiate(fragmentableObject);
            }
        }

        DestroyFragmentableObject(fragmentableObject);
    }

    private void DestroyFragmentableObject(FragmentableObject fragmentableObject)
    {
        Destroy(fragmentableObject.gameObject);
        FragmentableObjectDestroy?.Invoke();
    }
}
