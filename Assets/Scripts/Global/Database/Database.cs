using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Global.Database
{
    public class Database : MonoBehaviour
    {
        [SerializeField] private LevelStructScriptable _levels;

        public static Database Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
        }

        public string[] GetPackList()
        {
            HashSet<string> uniquePack = new HashSet<string>();

            for (int i = 0; i < _levels.LevelStruct.Length; i++)
            {
                uniquePack.Add(_levels.LevelStruct[i].PackID);
            }

            string[] packList = new string[uniquePack.Count];
            uniquePack.CopyTo(packList);

            return packList;
        }

        public string[] GetLevelList(string packID)
        {
            HashSet<string> uniqueLevel = new HashSet<string>();

            for (int i = 0; i < _levels.LevelStruct.Length; i++)
            {
                if (_levels.LevelStruct[i].PackID == packID)
                {
                    uniqueLevel.Add(_levels.LevelStruct[i].LevelID);
                }
            }

            string[] levelList = new string[uniqueLevel.Count];
            uniqueLevel.CopyTo(levelList);

            return levelList;
        }

        public LevelStruct GetLevelData(string levelID)
        {
            for (int i = 0; i < _levels.LevelStruct.Length; i++)
            {
                if (_levels.LevelStruct[i].LevelID == levelID)
                {
                    return _levels.LevelStruct[i];
                }
            }
            return new LevelStruct();
        }
    }
}
