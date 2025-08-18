using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;

    public event Action<List<FragmentableObject>> FragmentableObjectDestroy;
    public event Action<FragmentableObject> FragmentableObjectHit;

    private void OnEnable()
    {
        _raycaster.FragmentableObjectHit += NoticeFragmentableObjectHit;
        _spawner.FragmentableObjectDestroy += NoticeFragmentableObjectDestroy;
    }

    private void OnDisable()
    {
        _raycaster.FragmentableObjectHit -= NoticeFragmentableObjectHit;
        _spawner.FragmentableObjectDestroy -= NoticeFragmentableObjectDestroy;
    }

    private void NoticeFragmentableObjectHit(FragmentableObject fragmentableObject)
    {
        FragmentableObjectHit?.Invoke(fragmentableObject);
    }

    private void NoticeFragmentableObjectDestroy(List<FragmentableObject> fragmentableObjects)
    {
        FragmentableObjectDestroy?.Invoke(fragmentableObjects);
    }
}
