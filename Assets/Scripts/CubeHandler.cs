using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private void OnEnable()
    {
        _raycaster.CubeHit += FragmentationCube;
    }

    private void OnDisable()
    {
        _raycaster.CubeHit -= FragmentationCube;
    }

    private void FragmentationCube(Cube cube)
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

            Vector3 scale = cube.transform.localScale / multiplierSizeFragments;
            int chanceFragmentation = cube.ChanceFragmentation / fragmentationChanceReductionMultiplier;
            int numberFragmentations = UnityEngine.Random.Range(minFragmentation, maxFragmentation);

            cube.Initialize(chanceFragmentation, scale);
            newCubes = _spawner.SpawnFragments(cube, numberFragmentations);
            _explosion.ExplodeFragments(cube, newCubes);
        }
        else
        {
            _explosion.ExplodeCube(cube);
        }

        _spawner.DestroyCube(cube);
    }
}
