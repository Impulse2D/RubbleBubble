using DG.Tweening;
using System;
using UnityEngine;

namespace Diamonds
{
    public class DiamondPlusMover : MonoBehaviour
    {
        [SerializeField] private float _duractionMoving;

        public event Action<DiamondPlusMover> DiamondReleased;

        public void Move(Vector3 targetPosition)
        {
            transform.DOMove(targetPosition, _duractionMoving).onComplete = ReportReleased;
        }

        private void ReportReleased()
        {
            DiamondReleased?.Invoke(this);
        }
    }
}