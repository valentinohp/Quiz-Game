using QuizGame.Global.Database;
using QuizGame.Global.SaveData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QuizGame.Scene.Level
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private GameObject _levelPrefab;
        [SerializeField] private VerticalLayoutGroup _layoutGroup;
        private Level[] _levels;
        private string[] _levelList;

        private void Start()
        {
            _levelList = Database.Instance.GetLevelList(PlayerPrefs.GetString("SelectedPack"));
            LoadLevelList();
            InitLevelList(_levels);
        }

        private void LoadLevelList()
        {
            _levels = new Level[_levelList.Length];

            for (int i = 0; i < _levels.Length; i++)
            {
                GameObject levelObject = Instantiate(_levelPrefab);
                levelObject.transform.SetParent(_layoutGroup.transform, false);
                Level level = levelObject.GetComponent<Level>();
                Button button = level.GetSelectButton();
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(delegate { SelectLevel(level.GetLevelID()); });
                _levels[i] = level;
            }
        }

        public void SelectLevel(string levelID)
        {
            PlayerPrefs.SetString("SelectedLevel", levelID);
            SceneManager.LoadScene("Gameplay");
        }

        public Level[] GetPackList()
        {
            return _levels;
        }

        public void InitLevelList(Level[] levels)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].SetIDName(_levelList[i]);
                Button button = levels[i].GetSelectButton();

                if (SaveData.Instance.Data.CompletedLevel.Contains(levels[i].GetLevelID()))
                {
                    levels[i].GetCompleteImage().gameObject.SetActive(true);
                }
            }
        }
    }
}
