using UnityEngine;

namespace QuizGame.Global.Analytic
{
    public class Analytic : MonoBehaviour
    {
        public static Analytic Instance;

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

        public void TrackFinishLevel(string levelID)
        {
            Debug.Log("Analytics: Finised Level " + levelID);
        }

        public void TrackUnlockPack(string packID)
        {
            Debug.Log("Analytics: Unlocked Pack " + packID);
        }
    }
}
