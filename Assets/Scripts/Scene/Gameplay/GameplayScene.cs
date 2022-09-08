using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace QuizGame.Scene.Gameplay
{
    public class GameplayScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _selectedLevel;

        private void Start()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(QuitGame);
            _selectedLevel.text = "Level " + PlayerPrefs.GetString("SelectedLevel");
        }

        private void QuitGame()
        {
            SceneManager.LoadScene("Level");
        }
    }
}
