using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EventHub _eventHub;

    public event Action<List<Cube>> CubeDestroy;

    private void OnEnable()
    {
        _eventHub.CubeHit += FragmentationObject;
    }

    private void OnDisable()
    {
        _eventHub.CubeHit -= FragmentationObject;
    }

    private void FragmentationObject(Cube cube)
    {
        int multiplierSizeFragments = 2;
        int fragmentationChanceReductionMultiplier = 2;
        int minFragmentation = 2;
        int maxFragmentation = 7;
        int percentageMultiplier = 101;
        List<Cube> newCubes = new List<Cube>();

        int chanceSuccessfulFragmentation = UnityEngine.Random.Range(0, percentageMultiplier);

        if (chanceSuccessfulFragmentation <= cube.GetChanceFragmentation())
        {
            Vector3 scale = cube.transform.localScale / multiplierSizeFragments;
            int chanceFragmentation = cube.GetChanceFragmentation() / fragmentationChanceReductionMultiplier;

            int numberFragmentations = UnityEngine.Random.Range(minFragmentation, maxFragmentation);

            for (int i = 0; i < numberFragmentations; i++)
            {
                cube.Initialized(chanceFragmentation, scale);
                Cube newCube = Instantiate(cube);
                newCubes.Add(newCube);
            }
        }

        DestroyFragmentableObject(cube, newCubes);
    }

    private void DestroyFragmentableObject(Cube cube, List<Cube> Cubes)
    {
        Destroy(cube.gameObject);
        CubeDestroy?.Invoke(Cubes);
    }
}
