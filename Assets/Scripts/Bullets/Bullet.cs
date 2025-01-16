using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bullet : Ball
{
    private Vector3 _force;
    private bool _isMoved;
    private bool _isCriticalCollision;

    public event Action<Bullet> Released;
    public event Action<Bullet> CriticalCollisionDetected;

    public bool IsMoved => _isMoved;
    public bool IsCriticalCollision => _isCriticalCollision;

    private void OnDisable()
    {
        ActivateMeshRenderer();
    }

    public void ReportRelease()
    {
        Released?.Invoke(this);
    }

    public void SetForce(Vector3 force)
    {
        _force = force;
    }

    public void UseForce()
    {
        if (_force != null)
        {
            DisableKinematic();

            EnableIsMoved();

            Rigidbody.AddForce(_force, ForceMode.VelocityChange);
        }
    }

    public void DisableIsMoved()
    {
        _isMoved = false;
    }

    public void DeactiveMeshRenderer()
    {
        Renderer.enabled = false;
    }

    public void ReportCriticalCollisionDetected()
    {
        Debug.Log("Передал инфу о критическом повреждении");

        CriticalCollisionDetected?.Invoke(this);
    }

    public void EnableCriticalCollision()
    {
        _isCriticalCollision = true;
    }

    public void DisableCriticalCollision()
    {
        _isCriticalCollision = false;
    }

    private void EnableIsMoved()
    {
        _isMoved = true;
    }

    private void ActivateMeshRenderer()
    {
        Renderer.enabled = true;
    }
}
