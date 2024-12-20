using System;
using UnityEngine;

public class SpawnerBullets : Spawner<BulletsPool>
{
    [SerializeField] private MaterialsDispenser _materialsDispenser;

    private int _index;

    public event Action<Bullet> ProjectileCreated;

    public Bullet GetCreatedProjectile(Vector3 position, Quaternion rotation)
    {
        int valueLengthSubtracted = 1;
        int minValueIndex = 0;

        if (_index >= _materialsDispenser.MaterialsColoredBalls.Count - valueLengthSubtracted)
        {
            ResetIndexMaterialsColoredBalls(minValueIndex);
        }
        else
        {
            _index++;
        }

        Bullet newProjectile = ObjectsPool.GetObject(position, rotation);

        _materialsDispenser.GetRandomMaterial();

        newProjectile.SetMaterial(_materialsDispenser.MaterialsColoredBalls[_index]);

        newProjectile.DisableIsMoved();

        ReportProjectileCreated(newProjectile);

        return newProjectile;
    }

    private void ResetIndexMaterialsColoredBalls(int minValueIndex)
    {
        _index = minValueIndex;
    }

    private void ReportProjectileCreated(Bullet newProjectile)
    {
        ProjectileCreated?.Invoke(newProjectile);
    }
}
