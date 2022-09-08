using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuizGame.Scene.Gameplay
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private Slider _timeSlider;
        [SerializeField] private float _duration;
        private bool _isRunning;
        private float _time;

        public UnityAction OnTimerEnd;

        private void Update()
        {
            if (_isRunning)
            {
                _time += Time.deltaTime;
                if (_time > _duration)
                {
                    EndTimer();
                }
                
                _timeSlider.value = GetRemainingTime() / _duration;
            }
        }

        private void EndTimer()
        {
            _isRunning = false;
            OnTimerEnd?.Invoke();
        }

        public void StartTimer()
        {
            _isRunning = true;
            _time = 0f;
        }

        public float GetRemainingTime()
        {
            return _duration - _time;
        }
    }
}
