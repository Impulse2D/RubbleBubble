using System;
using LayerSpheres;
using UnityEngine;

namespace ColoredBalls
{
    public class SpawnerColoredBalls : Spawner<ColoredBallsPool>
    {
        [SerializeField] private SpawnerLayersSpheres _spawnerLayersSpheres;
        [SerializeField] private MaterialsDispenser _materialsDispenser;
        [SerializeField] private SpawnerPrototypeLayerSphere _spawnerPrototypeLayerSphere;

        private PrototypeLayerSphere _prototypeLayerSphere;
        private Vector3 _centerPrototypeLayerSphere;
        private Material _currentMaterial;
        private int _maxQuantitySectors;
        private int _quantityPointsSector;

        public event Action<int> ColoredSphereInitialized;
        public event Action<ColoredBall> ColoredSphereCollisionDetected;
        public event Action<ColoredBall> ColoredSphereReleased;
        public event Action CreatingCompleted;

        public void Init()
        {
            _prototypeLayerSphere = _spawnerPrototypeLayerSphere.GetCreatedInterLayer();

            _maxQuantitySectors = 3;

            _quantityPointsSector = _prototypeLayerSphere.SpawnPointsPositionsColoredBalls.Length / _maxQuantitySectors;
        }

        private void OnEnable()
        {
            _spawnerLayersSpheres.InterlayerInitialized += Initialize;
            _spawnerLayersSpheres.InterlayerReleased += Create;
        }

        private void OnDisable()
        {
            _spawnerLayersSpheres.InterlayerInitialized -= Initialize;
            _spawnerLayersSpheres.InterlayerReleased -= Create;
        }

        private void Initialize(int maxQuantityInterlayers)
        {
            int maxQuantityColoredSpheres = _prototypeLayerSphere.SpawnPointsPositionsColoredBalls.Length * maxQuantityInterlayers;

            for (int i = 0; i < maxQuantityColoredSpheres; i++)
            {
                ObjectsPool.Initialize();
            }

            ColoredSphereInitialized?.Invoke(maxQuantityColoredSpheres);

            _centerPrototypeLayerSphere = _prototypeLayerSphere.Rigidbody.centerOfMass;
        }

        private void Create(LayerSphere layerSphere)
        {
            Vector3 defaultScaleColoredSphere = new Vector3(0.15f, 0.15f, 0.15f);

            int indexPointColoredSphere = 0;

            for (int i = 0; i < _maxQuantitySectors; i++)
            {
                _currentMaterial = _materialsDispenser.GetRandomMaterial();

                for (int j = 0; j < _quantityPointsSector; j++)
                {
                    ColoredBall coloredSphere = ObjectsPool.GetRemoveLastObject();

                    coloredSphere.transform.position = _prototypeLayerSphere.SpawnPointsPositionsColoredBalls[indexPointColoredSphere];

                    coloredSphere.transform.LookAt(_centerPrototypeLayerSphere);

                    SetMaterial(coloredSphere, _currentMaterial);

                    SetParent(coloredSphere, layerSphere.transform);

                    AddSphere(coloredSphere, layerSphere);

                    SetDefaultLocalScale(coloredSphere, defaultScaleColoredSphere);

                    coloredSphere.SetLayerSphere(layerSphere);

                    ++indexPointColoredSphere;
                }
            }

            for (int i = 0; i < layerSphere.ColoredBalls.Count; i++)
            {
                ObjectsPool.ActiveObject(layerSphere.ColoredBalls[i].gameObject);

                layerSphere.ColoredBalls[i].CollisionDetected += ReportCollisionDetectedColoredSphere;

                layerSphere.ColoredBalls[i].Released += ReportReleasedColoredSphere;
            }

            CreatingCompleted?.Invoke();
        }

        private void ReportCollisionDetectedColoredSphere(ColoredBall coloredSphere)
        {
            coloredSphere.CollisionDetected -= ReportCollisionDetectedColoredSphere;

            ColoredSphereCollisionDetected?.Invoke(coloredSphere);
        }

        private void ReportReleasedColoredSphere(ColoredBall coloredSphere)
        {
            coloredSphere.Released -= ReportReleasedColoredSphere;

            ColoredSphereReleased?.Invoke(coloredSphere);
        }

        private void AddSphere(ColoredBall coloredSphere, LayerSphere layerSphere)
        {
            layerSphere.AddColoredBall(coloredSphere);
        }

        private void SetMaterial(ColoredBall coloredSphere, Material material)
        {
            coloredSphere.SetMaterial(material);
        }

        private void SetParent(ColoredBall coloredSphere, Transform parent)
        {
            coloredSphere.transform.SetParent(parent, false);
        }

        private void SetDefaultLocalScale(ColoredBall coloredSphere, Vector3 scale)
        {
            coloredSphere.transform.localScale = scale;
        }
    }
}
