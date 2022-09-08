using QuizGame.Global.Analytic;
using QuizGame.Global.Currency;
using QuizGame.Global.SaveData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QuizGame.Scene.Gameplay
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private Quiz _quiz;
        [SerializeField] private GameTimer _gameTimer;

        private void Start()
        {
            _quiz.OnQuizLoaded += StartGame;
            _gameTimer.OnTimerEnd += TimeOut;
        }

        private void StartGame()
        {
            Button[] buttons = _quiz.GetAnswerButtons();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].onClick.RemoveAllListeners();
                int temp = i;
                buttons[i].onClick.AddListener(delegate { AnswerQuestion(temp); });
            }

            _gameTimer.StartTimer();
        }

        private void AnswerQuestion(int answer)
        {
            if (answer == _quiz.GetCorrectAnswer())
            {
                if (_quiz.GetIsLastLevel())
                {
                    PublishFinishLevel(true);
                    GoToPackScene();
                }
                else
                {
                    PublishFinishLevel(false);
                    PlayerPrefs.SetString("SelectedLevel", _quiz.GetNextLevelID());
                    SceneManager.LoadScene("Gameplay");
                }
            }
            else
            {
                GoToLevelScene();
            }
        }

        private void PublishFinishLevel(bool isLast)
        {
            if (!SaveData.Instance.Data.CompletedLevel.Contains(_quiz.GetLevelID()))
            {
                Currency.Instance.AddCoin(20);
                SaveData.Instance.Data.CompletedLevel.Add(_quiz.GetLevelID());
            }

            if (isLast && !SaveData.Instance.Data.CompletedPack.Contains(_quiz.GetPackID()))
            {
                SaveData.Instance.Data.CompletedPack.Add(_quiz.GetPackID());
            }

            SaveData.Instance.Save();
            Analytic.Instance.TrackFinishLevel(_quiz.GetLevelID());
        }

        private void TimeOut()
        {
            GoToLevelScene();
        }

        private void GoToLevelScene()
        {
            SceneManager.LoadScene("Level");
        }

        private void GoToPackScene()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}
