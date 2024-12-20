using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private float _power = 10;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private BulletsReloader _projectileReloader;

    private Camera _mainCamera;
    private Vector3 _forceProjectile;
    private Vector3 _endPositionProjectile;

    public Vector3 ForceProjectile => _forceProjectile;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _inputReader.AimingReleased += SetTrajectoryPath;
        _inputReader.ShootReleased += TryReleaseProjectile;
        _inputReader.ReloadReleased += TryChangeProjectile;
    }

    private void OnDisable()
    {
        _inputReader.AimingReleased -= SetTrajectoryPath;
        _inputReader.ShootReleased -= TryReleaseProjectile;
        _inputReader.ReloadReleased -= TryChangeProjectile;
    }

    private void TryChangeProjectile()
    {
        if (IsCurrentProjectile())
        {
            _projectileReloader.CurrentProjectile.DisableKinematic();

            _projectileReloader.CurrentProjectile.DeactiveMeshRenderer();

            _projectileReloader.Recharge();
        }
    }

    private void SetTrajectoryPath(Vector3 position)
    {
        float enter;
        Vector3 direction = new Vector3(0f, 1f, -1f);

        Ray ray = _mainCamera.ScreenPointToRay(position);

        new Plane(direction, transform.position).Raycast(ray, out enter);

        _endPositionProjectile = ray.GetPoint(enter);

        _forceProjectile = (_endPositionProjectile - transform.position) * _power;
    }

    private void TryReleaseProjectile()
    {
        if (IsCurrentProjectile())
        {
            _projectileReloader.CurrentProjectile.SetForce(_forceProjectile);
            _projectileReloader.CurrentProjectile.UseForce();

            _projectileReloader.Recharge();
        }
    }

    private bool IsCurrentProjectile()
    {
        return _projectileReloader.CurrentProjectile != null;
    }
}