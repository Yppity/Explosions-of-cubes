using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class RandomColorSetter : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
