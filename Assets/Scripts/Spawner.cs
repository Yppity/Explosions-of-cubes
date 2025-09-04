using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public List<Cube> SpawnFragments(Cube cube, int numnerFragments, int chanceFragmentation, Vector3 scale)
    {
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < numnerFragments; i++)
        {
            Cube newCube = Instantiate(cube);
            newCube.Initialize(chanceFragmentation, scale);
            newCubes.Add(newCube);
        }

        return newCubes;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
