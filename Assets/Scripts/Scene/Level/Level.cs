using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QuizGame.Scene.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private TMP_Text _levelNameLabel;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Image _completeImage;

        private string _levelID;
        private string _levelName;
        private bool _isCompleted;

        public void SetIDName(string levelID)
        {
            _levelID = levelID;
            _levelName = levelID;
            _levelNameLabel.text = "Level " + _levelName;
        }

        public string GetLevelID()
        {
            return _levelID;
        }

        public Button GetSelectButton()
        {
            return _selectButton;
        }

        public Image GetCompleteImage()
        {
            return _completeImage;
        }
    }
}
