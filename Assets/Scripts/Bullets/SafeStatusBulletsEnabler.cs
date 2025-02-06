using UnityEngine;

public class SafeStatusBulletsEnabler : MonoBehaviour
{
    [SerializeField] private LifeService _lifeService;
    [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstLayerSphere;

    private void OnEnable()
    {
        _lifeService.LivesExhausted += TryRemoveAllProjectile;
    }

    private void OnDisable()
    {
        _lifeService.LivesExhausted -= TryRemoveAllProjectile;
    }

    private void TryRemoveAllProjectile()
    {
        float radius = 1000f;

        Collider[] overlappedColliders = Physics.OverlapSphere(_spawnPointFirstLayerSphere.transform.position, radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            if (overlappedColliders[i] != null)
            {
                if (overlappedColliders[i].TryGetComponent(out Bullet projectile))
                {
                    if (projectile.IsMoved == true)
                    {
                        projectile.DisableIsMoved();
                    }
                }
            }
        }
    }
}
