using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputController _inputController;
    private bool _isAiming;
    private bool _isReloading;

    public event Action<Vector3> AimingReleased;
    public event Action AimingEnabled;
    public event Action AimingDisabled;
    public event Action ShootReleased;
    public event Action ReloadReleased;

    private void OnEnable()
    {
        _inputController = new InputController();

        _isAiming = false;

        _inputController.ShootController.Shoot.canceled += TryShoot;
        _inputController.AimController.Aimimg.performed += ActivateAiming;
        _inputController.AimController.Aimimg.canceled += DeactivateAiming;
        _inputController.BulletsReloader.Reload.performed += ReportReloading;

        _inputController.Enable();
    }

    private void OnDisable()
    {
        _inputController.ShootController.Shoot.canceled -= TryShoot;
        _inputController.AimController.Aimimg.performed -= ActivateAiming;
        _inputController.AimController.Aimimg.canceled -= DeactivateAiming;
        _inputController.BulletsReloader.Reload.performed -= ReportReloading;

        _inputController.Disable();
    }

    private void Update()
    {
        TryDisableAiming();

        TryAim();
    }

    public void EnableReloading()
    {
        _isReloading = true;
    }

    public void DisableReloading()
    {
        _isReloading = false;
    }

    private void EnableAiming()
    {
        _isAiming = true;
    }

    private void DisableeAiming()
    {
        ReportAimingDisabled();

        _isAiming = false;
    }

    private void TryDisableAiming()
    {
        if (IsRelod() == true)
        {
            DisableeAiming();
        }
    }

    private void TryAim()
    {
        if (IsAiming() == true)
        {
            ReportEnabledAiming();

            TakeAim();
        }
    }

    private void TakeAim()
    {
        Vector3 position = _inputController.AimController.AimPosition.ReadValue<Vector2>();

        ReportAimingReleased(position);
    }
    private void ReportReloading(InputAction.CallbackContext context)
    {
        ReportReloadReleased();
    }

    private void ActivateAiming(InputAction.CallbackContext context)
    {
        EnableAiming();
    }

    private void DeactivateAiming(InputAction.CallbackContext context)
    {
        ReportAimingDisabled();

        DisableeAiming();
    }

    private void TryShoot(InputAction.CallbackContext context)
    {
        if (IsRelod() == false)
        {
            ReportShootReleased();
        }
    }

    private bool IsAiming()
    {
        return _isAiming;
    }

    private bool IsRelod()
    {
        return _isReloading;
    }

    private void ReportEnabledAiming()
    {
        AimingEnabled?.Invoke();
    }

    private void ReportAimingDisabled()
    {
        AimingDisabled?.Invoke();
    }

    private void ReportReloadReleased()
    {
        ReloadReleased?.Invoke();
    }

    private void ReportAimingReleased(Vector3 position)
    {
        AimingReleased?.Invoke(position);
    }

    private void ReportShootReleased()
    {
        ShootReleased?.Invoke();
    }

}
