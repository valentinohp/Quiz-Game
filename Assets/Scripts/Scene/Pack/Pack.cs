using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QuizGame.Scene.Pack
{
    public class Pack : MonoBehaviour
    {
        [SerializeField] private TMP_Text _packNameLabel;
        [SerializeField] private TMP_Text _unlockCostLabel;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _unlockButton;
        [SerializeField] private Image _completeImage;

        private string _packID;
        private string _packName;
        private bool _isCompleted;
        private bool _isUnlocked;
        [SerializeField] private int _unlockCost = 100;

        public void SetIDName(string packID)
        {
            _packID = packID;
            _packName = packID;
            _packNameLabel.text = "Level Pack " + _packName;
            _unlockCostLabel.text = "Unlock \n" + _unlockCost + " Gold";
        }

        public string GetPackID()
        {
            return _packID;
        }

        public Button GetSelectButton()
        {
            return _selectButton;
        }

        public Image GetCompleteImage()
        {
            return _completeImage;
        }

        public int GetUnlockCost()
        {
            return _unlockCost;
        }

        public TMP_Text GetUnlockCostLabel()
        {
            return _unlockCostLabel;
        }

        public Button GetUnlockButton()
        {
            return _unlockButton;
        }
    }
}
