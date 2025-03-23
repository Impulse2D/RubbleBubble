using System.Collections;
using UnityEngine;
using YG;

namespace Services
{
    public class LeaderBoardService : MonoBehaviour
    {
        private const string NameLiderBoard = "LevelScore";

        [SerializeField] private LevelService _levelService;

        private int _newScore;

        private int _currentScore;
        private Coroutine _coroutine;

        public void Init()
        {
            _newScore = YandexGame.savesData.numberLevel;
            _currentScore = YandexGame.savesData.currentRecord;

            if (YandexGame.auth == true)
            {
                AddNewLeaderboardScores();
            }
        }

        public void AddNewLeaderboardScores()
        {
            if (_newScore > _currentScore)
            {
                YandexGame.NewLeaderboardScores(NameLiderBoard, _newScore);

                YandexGame.savesData.currentRecord = _newScore;

                SaveDataLeaderboard();
            }
            else
            {
                YandexGame.NewLeaderboardScores(NameLiderBoard, _currentScore);

                YandexGame.savesData.currentRecord = _currentScore;

                SaveDataLeaderboard();
            }
        }

        private void SaveDataLeaderboard()
        {
            if (_coroutine != null)
            {
                StopCoroutine(CountDelayAfterSaveValueRecord());
            }

            StartCoroutine(CountDelayAfterSaveValueRecord());
        }

        private IEnumerator CountDelayAfterSaveValueRecord()
        {
            float delay = 1f;

            WaitForSeconds timeWait = new WaitForSeconds(delay);

            yield return timeWait;

            YandexGame.SaveProgress();
        }
    }
}