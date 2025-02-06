using System;
using UnityEngine;

public class AimingCancelersViewsChanger : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ObjectsChangerService _objectsChangerService;
    [SerializeField] private AimingCanceler _aimingCancelerButton;
    [SerializeField] private AimCancelerPanel _aimCancelerPanel;

    public event Action ButtonShowed;
    public event Action PanelShowed;
    public event Action PanelCanceled;

    private void OnEnable()
    {
        _inputReader.AimingEnabled += ShowAimingCancelerButton;
        _inputReader.AimingDisabled += HideAimingCancelerButton;

        _aimingCancelerButton.AbilityCancelAimingEnabled += ShowAimCancelerPanel;
        _aimingCancelerButton.AbilityCancelAimingDisabled += HideAimCancelerPanel;
    }

    private void OnDisable()
    {
        _inputReader.AimingEnabled -= ShowAimingCancelerButton;
        _inputReader.AimingDisabled -= HideAimingCancelerButton;

        _aimingCancelerButton.AbilityCancelAimingEnabled -= ShowAimCancelerPanel;
        _aimingCancelerButton.AbilityCancelAimingDisabled -= HideAimCancelerPanel;
    }

    private void ShowAimingCancelerButton()
    {
        _objectsChangerService.EnableObject(_aimingCancelerButton.gameObject);

        ButtonShowed?.Invoke();
    }

    private void HideAimingCancelerButton()
    {
        _objectsChangerService.DisableObject(_aimingCancelerButton.gameObject);
    }

    private void ShowAimCancelerPanel()
    {
        _objectsChangerService.EnableObject(_aimCancelerPanel.gameObject);

        PanelShowed?.Invoke();
    }

    private void HideAimCancelerPanel()
    {
        _objectsChangerService.DisableObject(_aimCancelerPanel.gameObject);

        PanelCanceled?.Invoke();
    }

}
