using System;
using LayerSpheres;
using UnityEngine;

namespace ColoredBalls
{
    public class SpawnerColoredBalls : Spawner<ColoredBallsPool>
    {
        [SerializeField] private SpawnerLayersSpheres _spawnerLayersSpheres;
        [SerializeField] private MaterialsDispenser _materialsColoredBallsDispenser;
        [SerializeField] private SpawnerPrototypeLayerSphere _spawnerPrototypeLayerSphere;

        private PrototypeLayerSphere _prototypeLayerSphere;
        private Vector3 _centerPointPositionPrototypeLayerSphere;
        private Material _currentMaterialColoredBall;
        private int _maxQuantityColoredBallsSectors;
        private int _quantityPointsColoredBallsSector;

        public event Action<int> ColoredBallInitialized;
        public event Action<ColoredBall> ColoredBallCollisionDetected;
        public event Action<ColoredBall> ColoredBallReleased;
        public event Action CreatingColoredBallsCompleted;

        public void Init()
        {
            _prototypeLayerSphere = _spawnerPrototypeLayerSphere.GetCreatedInterLayer();

            _maxQuantityColoredBallsSectors = 3;

            _quantityPointsColoredBallsSector = _prototypeLayerSphere.SpawnPointsPositionsColoredBalls.Length / _maxQuantityColoredBallsSectors;
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

            ColoredBallInitialized?.Invoke(maxQuantityColoredSpheres);

            _centerPointPositionPrototypeLayerSphere = _prototypeLayerSphere.Rigidbody.centerOfMass;
        }

        private void Create(LayerSphere layerSphere)
        {
            Vector3 defaultScaleColoredSphere = new Vector3(0.15f, 0.15f, 0.15f);

            int indexPointColoredSphere = 0;

            for (int i = 0; i < _maxQuantityColoredBallsSectors; i++)
            {
                _currentMaterialColoredBall = _materialsColoredBallsDispenser.GetRandomMaterial();

                for (int j = 0; j < _quantityPointsColoredBallsSector; j++)
                {
                    ColoredBall coloredBall = ObjectsPool.GetRemoveLastObject();

                    coloredBall.transform.position = _prototypeLayerSphere.SpawnPointsPositionsColoredBalls[indexPointColoredSphere];

                    coloredBall.transform.LookAt(_centerPointPositionPrototypeLayerSphere);

                    SetMaterial(coloredBall, _currentMaterialColoredBall);

                    SetParent(coloredBall, layerSphere.transform);

                    AddSphere(coloredBall, layerSphere);

                    SetDefaultLocalScaleColoredBall(coloredBall, defaultScaleColoredSphere);

                    coloredBall.SetLayerSphere(layerSphere);

                    ++indexPointColoredSphere;
                }
            }

            for (int i = 0; i < layerSphere.ColoredBalls.Count; i++)
            {
                ObjectsPool.ActiveObject(layerSphere.ColoredBalls[i].gameObject);

                layerSphere.ColoredBalls[i].CollisionDetected += ReportCollisionDetectedColoredSphere;

                layerSphere.ColoredBalls[i].Released += ReportReleasedColoredSphere;
            }

            CreatingColoredBallsCompleted?.Invoke();
        }

        private void ReportCollisionDetectedColoredSphere(ColoredBall coloredBall)
        {
            coloredBall.CollisionDetected -= ReportCollisionDetectedColoredSphere;

            ColoredBallCollisionDetected?.Invoke(coloredBall);
        }

        private void ReportReleasedColoredSphere(ColoredBall coloredBall)
        {
            coloredBall.Released -= ReportReleasedColoredSphere;

            ColoredBallReleased?.Invoke(coloredBall);
        }

        private void AddSphere(ColoredBall coloredBall, LayerSphere layerSphere)
        {
            layerSphere.AddColoredBall(coloredBall);
        }

        private void SetMaterial(ColoredBall coloredBall, Material material)
        {
            coloredBall.SetMaterial(material);
        }

        private void SetParent(ColoredBall coloredBall, Transform parent)
        {
            coloredBall.transform.SetParent(parent, false);
        }

        private void SetDefaultLocalScaleColoredBall(ColoredBall coloredBall, Vector3 scale)
        {
            coloredBall.transform.localScale = scale;
        }
    }
}
