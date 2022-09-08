using UnityEngine;

namespace QuizGame.Global.Currency
{
    public class Currency : MonoBehaviour
    {
        private int _coin;

        public static Currency Instance;

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

            _coin = SaveData.SaveData.Instance.Data.Coin;
        }

        public int GetCoin()
        {
            return _coin;
        }   

        public void AddCoin(int amount)
        {
            _coin += amount;
            SaveData.SaveData.Instance.Data.Coin = _coin;
        }

        public bool SpendCoin(int amount)
        {
            if (_coin >= amount)
            {
                _coin -= amount;
                return true;
            }
            return false;
        }
    }
}
