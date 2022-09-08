using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace QuizGame.Scene.Home
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private void Start()
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(StartPlay);
        }

        private void StartPlay()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}
