using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Cube> SpawnFragments(Cube cube, int numnerFragments)
    {
        List<Cube> newCubes = new List<Cube>();

        for (int i = 0; i < numnerFragments; i++)
        {
            Cube newCube = Instantiate(cube);
            newCubes.Add(newCube);
        }

        return newCubes;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
