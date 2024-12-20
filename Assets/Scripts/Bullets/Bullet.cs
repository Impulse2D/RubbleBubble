using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bullet : Ball
{
    private Vector3 _force;
    private bool _isMoved;

    public event Action<Bullet> Released;

    public bool IsMoved => _isMoved;

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

    private void EnableIsMoved()
    {
        _isMoved = true;
    }

    private void ActivateMeshRenderer()
    {
        Renderer.enabled = true;
    }

    public void DisableIsMoved()
    {
        _isMoved = false;
    }

    public void DeactiveMeshRenderer()
    {
        Renderer.enabled = false;
    }
}
