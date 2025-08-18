using System;
using System.Collections.Generic;
using UnityEngine;

public class EventHub : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;

    public event Action<List<Cube>> CubeDestroy;
    public event Action<Cube> CubeHit;

    private void OnEnable()
    {
        _raycaster.Cube += NoticeFragmentableObjectHit;
        _spawner.CubeDestroy += NoticeFragmentableObjectDestroy;
    }

    private void OnDisable()
    {
        _raycaster.Cube -= NoticeFragmentableObjectHit;
        _spawner.CubeDestroy -= NoticeFragmentableObjectDestroy;
    }

    private void NoticeFragmentableObjectHit(Cube cube)
    {
        CubeHit?.Invoke(cube);
    }

    private void NoticeFragmentableObjectDestroy(List<Cube> cube)
    {
        CubeDestroy?.Invoke(cube);
    }
}
