using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace QuizGame.Scene.Level
{
    public class LevelScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _selectedPack;

        private void Start()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
            _selectedPack.text = "Level Pack " + PlayerPrefs.GetString("SelectedPack");
        }

        private void GoBack()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}
