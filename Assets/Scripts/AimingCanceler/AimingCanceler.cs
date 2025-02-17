using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AimingCanceling
{
    public class AimingCanceler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private InputReader _inputReader;

        public event Action AbilityCancelAimingEnabled;
        public event Action AbilityCancelAimingDisabled;

        private void OnDisable()
        {
            ReportAbilityCancelAimingDisabled();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (IsAim() == true)
            {
                _inputReader.EnableCanceledAiming();

                AbilityCancelAimingEnabled?.Invoke();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (IsAim() == true)
            {
                _inputReader.DisableCanceledAiming();

                ReportAbilityCancelAimingDisabled();
            }
        }

        private bool IsAim()
        {
            return _inputReader.IsAim;
        }

        private void ReportAbilityCancelAimingDisabled()
        {
            AbilityCancelAimingDisabled?.Invoke();
        }
    }
}
