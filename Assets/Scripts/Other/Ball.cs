using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public abstract class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Renderer _renderer;
    private Color _color;

    public Color Color => _color;
    protected Rigidbody Rigidbody => _rigidBody;
    protected Renderer Renderer => _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        _rigidBody = GetComponent<Rigidbody>();

        EnableKinematic();
    }

    public void SetMaterial(Material material)
    {
        _renderer.material = material;

        SetColor(_renderer.material.color);
    }

    public void DisableKinematic()
    {
        _rigidBody.isKinematic = false;
    }

    private void SetColor(Color color)
    {
        _color = color;
    }

    private void EnableKinematic()
    {
        Rigidbody.isKinematic = true;
    }
}
