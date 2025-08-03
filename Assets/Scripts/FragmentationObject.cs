using UnityEngine;

public class FragmentationObject : MonoBehaviour
{
    [SerializeField] private int _chanceFragmentation = 100;
    [SerializeField] private Explosion explosion;
    [SerializeField] private float _explosionRadius = 10f;
    [SerializeField] private float _explosionForce = 500f;

    private void OnEnable()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        Fragmentation();
        explosion.Explode(_explosionForce, _explosionRadius);
        Destroy(gameObject);
    }

    private void Fragmentation()
    {
        float multiplierSizeFragments = 0.5f; 
        int fragmentationChanceReductionMultiplier = 2;
        int minFragmentation = 2;
        int maxFragmentation = 7;
        int percentageMultiplier = 101;

        int chanceSuccessfulFragmentation = Random.Range(0, percentageMultiplier);

        if (chanceSuccessfulFragmentation <= _chanceFragmentation)
        {
            transform.localScale *= multiplierSizeFragments;
            _explosionForce *= multiplierSizeFragments;
            _explosionRadius *= multiplierSizeFragments;
            _chanceFragmentation = _chanceFragmentation / fragmentationChanceReductionMultiplier;

            int numberFragmentations = Random.Range(minFragmentation, maxFragmentation);

            for (int i = 0; i < numberFragmentations; i++)
                Instantiate(gameObject);
        }
    }
}
