using UnityEngine;

public class LivesReducing : MonoBehaviour
{
    [SerializeField] private SpawnerBullets _spawnerBullets;
    [SerializeField] private LifeService _lifeService;

    private void OnEnable()
    {
        _spawnerBullets.CriticalCollisionProjectileReported += TryReduceQuantitylives;
    }

    private void OnDisable()
    {
        _spawnerBullets.CriticalCollisionProjectileReported -= TryReduceQuantitylives;
    }

    private void TryReduceQuantitylives()
    {
        _lifeService.TryReduceQuantitylives();
    }
}
