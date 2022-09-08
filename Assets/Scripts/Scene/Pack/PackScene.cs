using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using QuizGame.Global.Currency;
using TMPro;

namespace QuizGame.Scene.Pack
{
    public class PackScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private TMP_Text _coins;

        private void Start()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
            _coins.text = Currency.Instance.GetCoin().ToString();
        }

        private void GoBack()
        {
            SceneManager.LoadScene("Home");
        }

        public void UpdateCoin()
        {
            _coins.text = Currency.Instance.GetCoin().ToString();
        }
    }
}
