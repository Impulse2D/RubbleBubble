using UnityEngine;
using UnityEngine.EventSystems;

public class Game—ontrolBlocker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private InputReader _inputReader;

    public void OnPointerDown(PointerEventData eventData)
    {
        _inputReader.DisableIs—anShoot();

        _inputReader.EnableControlBlocking();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputReader.DisableControlBlocking();
    }
}