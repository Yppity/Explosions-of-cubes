using System.Collections.Generic;
using UnityEngine;

public class CubeInteraction : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private void OnEnable()
    {
        _raycaster.CubeHit += ProcessCubeClick;
    }

    private void OnDisable()
    {
        _raycaster.CubeHit -= ProcessCubeClick;
    }

    private void ProcessCubeClick(Cube cube)
    {
        int multiplierSizeFragments = 2;
        int fragmentationChanceReductionMultiplier = 2;
        int minFragmentation = 2;
        int maxFragmentation = 7;
        int percentageMultiplier = 101;

        int chanceSuccessfulFragmentation = UnityEngine.Random.Range(0, percentageMultiplier);

        if (chanceSuccessfulFragmentation <= cube.ChanceFragmentation)
        {
            List<Cube> newCubes = new List<Cube>();

            Vector3 newScale = cube.transform.localScale / multiplierSizeFragments;
            int newChanceFragmentation = cube.ChanceFragmentation / fragmentationChanceReductionMultiplier;
            int numberFragmentations = UnityEngine.Random.Range(minFragmentation, maxFragmentation);

            newCubes = _spawner.SpawnFragments(cube, numberFragmentations, newChanceFragmentation, newScale);
            _explosion.ExplodeFragments(cube, newCubes);
        }
        else
        {
            _explosion.ExplodeCube(cube);
        }

        _spawner.DestroyCube(cube);
    }
}
