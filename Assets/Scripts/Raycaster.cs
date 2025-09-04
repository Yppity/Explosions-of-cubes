using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private int _inputButton = 0;

    public event Action<Cube> CubeHit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_inputButton))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                if (hit.collider.TryGetComponent(out Cube fragmentable))
                    CubeHit?.Invoke(fragmentable);
        }
    }
}
