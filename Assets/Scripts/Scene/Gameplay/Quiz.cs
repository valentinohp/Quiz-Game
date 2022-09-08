using UnityEngine;
using UnityEngine.UI;
using TMPro;
using QuizGame.Global.Database;
using UnityEngine.Events;

namespace QuizGame.Scene.Gameplay
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private Image _hintImage;
        [SerializeField] private GameObject _optionPrefab;
        [SerializeField] private VerticalLayoutGroup _layoutGroup;
        private Button[] _answerButtons;
        private LevelStruct _level;
        private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        public UnityAction OnQuizLoaded;

        private void Start()
        {
            _level = Database.Instance.GetLevelData(PlayerPrefs.GetString("SelectedLevel"));
            InitQuiz(_level);
        }

        public void InitQuiz(LevelStruct level)
        {
            _questionText.text = level.Question;
            _hintImage.sprite = Resources.Load<Sprite>(@"Sprites/" + level.Hint);
            _answerButtons = new Button[level.Choice.Length];
            for (int i = 0; i < level.Choice.Length; i++)
            {
                GameObject optionObject = Instantiate(_optionPrefab);
                optionObject.transform.SetParent(_layoutGroup.transform, false);
                Button optionButton = optionObject.GetComponentInChildren<Button>();
                optionButton.GetComponentInChildren<TMP_Text>().text = _alphabet[i] + ". " + level.Choice[i % _alphabet.Length];
                _answerButtons[i] = optionButton;
            }

            OnQuizLoaded?.Invoke();
        }

        public Button[] GetAnswerButtons()
        {
            return _answerButtons;
        }

        public int GetCorrectAnswer()
        {
            return _level.Answer;
        }

        public bool GetIsLastLevel()
        {
            return Database.Instance.GetLevelList(_level.PackID).Length == int.Parse(_level.LevelID.Split("-")[1]);
        }

        public string GetLevelID()
        {
            return _level.LevelID;
        }

        public string GetPackID()
        {
            return _level.PackID;
        }

        public string GetNextLevelID()
        {
            return _level.PackID + "-" + (int.Parse(_level.LevelID.Split("-")[1]) + 1);
        }
    }
}
