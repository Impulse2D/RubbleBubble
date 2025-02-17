using Services;
using UnityEngine;

namespace TeachingStage
{
    public class StageTeaching : MonoBehaviour
    {
        [SerializeField] private StagesTeachingService _stagesTeachingService;
        [SerializeField] private ObjectsChangerService _objectsChangerService;
        [SerializeField] private InputReader _inputReader;

        private int _id;

        public StagesTeachingService StagesTeachingService => _stagesTeachingService;
        public ObjectsChangerService ObjectsChangerService => _objectsChangerService;
        public InputReader InputReader => _inputReader;

        public int Id => _id;

        public void SetId(int id)
        {
            _id = id;
        }
    }
}
