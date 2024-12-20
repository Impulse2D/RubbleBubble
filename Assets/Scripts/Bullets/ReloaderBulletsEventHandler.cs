using UnityEngine;
using UnityEngine.EventSystems;

public class ReloaderBulletsEventHandler : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] private InputReader _inputReader;

    public void OnPointerDown(PointerEventData eventData)
    {
        _inputReader.EnableReloading();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _inputReader.DisableReloading();
    }
}
