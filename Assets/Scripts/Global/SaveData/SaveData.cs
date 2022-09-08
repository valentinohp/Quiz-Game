using System.IO;
using UnityEngine;

namespace QuizGame.Global.SaveData
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance;
        public Data Data = new Data();

        private string _path;

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

            _path = Application.persistentDataPath + "/SaveData.json";
            Load();

            if (Data.UnlockedPack.Count == 0)
            {
                Data.UnlockedPack.Add("A");
            }
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(Data);
            File.WriteAllText(_path, json);
        }

        public void Load()
        {
            if (File.Exists(_path))
            {
                string fileContents = File.ReadAllText(_path);
                Data = JsonUtility.FromJson<Data>(fileContents);
            }
            else
            {
                Save();
                Load();
            }
        }
    }
}