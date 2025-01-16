using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputController _inputController;
    private bool _isAiming;
    private bool _isControlBlocked;
    private bool _is�anShoot;

    public event Action<Vector3> AimingReleased;
    public event Action AimingEnabled;
    public event Action AimingDisabled;
    public event Action ShootReleased;
    public event Action ReloadReleased;

    public bool IsAim => _isAiming;
    public bool IsBlockedControl => _isControlBlocked;

    private void OnEnable()
    {
        _inputController = new InputController();

        _isControlBlocked = false;
        _isAiming = false;
        _is�anShoot = false;

        _inputController.ShootController.Shoot.canceled += TryShoot;
        _inputController.AimController.Aimimg.performed += ActivateAiming;
        _inputController.AimController.Aimimg.canceled += DeactivateAiming;
        _inputController.BulletsReloader.Reload.performed += TryReportReloading;

        _inputController.Enable();
    }

    private void OnDisable()
    {
        _inputController.ShootController.Shoot.canceled -= TryShoot;
        _inputController.AimController.Aimimg.performed -= ActivateAiming;
        _inputController.AimController.Aimimg.canceled -= DeactivateAiming;
        _inputController.BulletsReloader.Reload.performed -= TryReportReloading;

        _inputController.Disable();
    }

    private void Update()
    {
        TryDisableAiming();

        TryAim();
    }

    public void EnableControlBlocking()
    {
        _isControlBlocked = true;
    }

    public void DisableControlBlocking()
    {
        _isControlBlocked = false;
    }

    public void DisableIs�anShoot()
    {
        _is�anShoot = false;
    }

    private void EnableIs�anShoot()
    {
        _is�anShoot = true;
    }

    private void EnableAiming()
    {
        _isAiming = true;
    }

    private void DisableAiming()
    {
        ReportAimingDisabled();

        _isAiming = false;
    }

    private void TryDisableAiming()
    {
        if (IsControlBlocked() == true)
        {
            DisableAiming();
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

    private void TryReportReloading(InputAction.CallbackContext context)
    {
        if (IsControlBlocked() == true)
        {
            ReportReloadReleased();
        }
    }

    private void ActivateAiming(InputAction.CallbackContext context)
    {
        EnableIs�anShoot();

        EnableAiming();
    }

    private void DeactivateAiming(InputAction.CallbackContext context)
    {
        ReportAimingDisabled();

        DisableAiming();
    }

    private void TryShoot(InputAction.CallbackContext context)
    {
        if (IsControlBlocked() == false && IsShotAttempted() == true)
        {
            ReportShootReleased();
        }
    }

    private bool IsAiming()
    {
        return _isAiming;
    }

    private bool IsControlBlocked()
    {
        return _isControlBlocked;
    }

    private bool IsShotAttempted()
    {
        return _is�anShoot;
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
