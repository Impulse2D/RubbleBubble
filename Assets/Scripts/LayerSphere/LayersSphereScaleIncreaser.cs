using System.Collections.Generic;
using ColoredBalls;
using UnityEngine;

namespace LayerSpheres
{
    public class LayersSphereScaleIncreaser : MonoBehaviour
    {
        private const float FirstIdentifier = 1f;
        private const float SecondIdentifier = 2f;

        [SerializeField] private SpawnPointFirstLayerSphere _spawnPointFirstInterlayer;
        [SerializeField] private SpawnerColoredBalls _spawnerColoredBalls;
        [SerializeField] private float _radius = 100f;
        [SerializeField] private float _valueFirstSizeLayerSphere = 1.5f;
        [SerializeField] private float _valueSecondSizeLayerSphere = 1.8f;

        private List<Vector3> _scaleInterlayer;
        private Vector3 _firstScaleTarget;
        private Vector3 _secondScaleTarget;

        public void Init()
        {
            _scaleInterlayer = new List<Vector3>
        {
            new Vector3(_valueFirstSizeLayerSphere, _valueFirstSizeLayerSphere, _valueFirstSizeLayerSphere),
            new Vector3(_valueSecondSizeLayerSphere, _valueSecondSizeLayerSphere, _valueSecondSizeLayerSphere),
        };

            _firstScaleTarget = _scaleInterlayer[0];
            _secondScaleTarget = _scaleInterlayer[1];
        }

        private void OnEnable()
        {
            _spawnerColoredBalls.CreatingColoredBallsCompleted += IncreaseInterlayers;
        }

        private void OnDisable()
        {
            _spawnerColoredBalls.CreatingColoredBallsCompleted -= IncreaseInterlayers;
        }

        private void IncreaseInterlayers()
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(_spawnPointFirstInterlayer.transform.position, _radius);

            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i].TryGetComponent(out LayerSphere interlayer) == false) continue;

                interlayer.IncreaseIdentifier();

                TryIncreaseInterlayer(FirstIdentifier, interlayer, _firstScaleTarget);
                TryIncreaseInterlayer(SecondIdentifier, interlayer, _secondScaleTarget);
            }
        }

        private void TryIncreaseInterlayer(float identifierInterlayer, LayerSphere interlayer, Vector3 targetScale)
        {
            if (interlayer.Identifier != identifierInterlayer)
                return;

            interlayer.IncreaseScale(targetScale);
        }
    }
}