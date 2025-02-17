using UnityEngine;

namespace Diamonds
{
    public class DiamondPlusDisabler : MonoBehaviour
    {
        [SerializeField] private SpawnerDiamondsPlus _spawnerDiamondsPlus;
        [SerializeField] private DiamondPlusPool _diamondPlusPool;

        private void OnEnable()
        {
            _spawnerDiamondsPlus.DiamondPlusReleased += RemoveDiamondPlus;
        }

        private void OnDisable()
        {
            _spawnerDiamondsPlus.DiamondPlusReleased -= RemoveDiamondPlus;
        }

        private void RemoveDiamondPlus(DiamondPlusMover diamondPlus)
        {
            _diamondPlusPool.ReturnObject(diamondPlus);
        }
    }
}

