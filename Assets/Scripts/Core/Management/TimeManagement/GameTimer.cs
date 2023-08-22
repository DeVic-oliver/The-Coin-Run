namespace Assets.Scripts.Core.Management.TimeManagement
{
    using Assets.Scripts.Core.Management.DataManagement;
    using Assets.Scripts.Core.Services;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Events;

    public class GameTimer : MonoBehaviour
    {
        public UnityEvent OnTimeEnds;

        [SerializeField] private int _maxTimeInSeconds = 20;
        [SerializeField] private TextMeshProUGUI _gameTimerTMP;

        private float _currentTime;
        private bool _shouldCount;


        void Start()
        {
            ResetTimer();
            StartTimer();
        }

        public void ResetTimer()
        {
            _currentTime = _maxTimeInSeconds;
            UpdateTimerTMP(_currentTime);
        }

        public void StartTimer()
        {
            _shouldCount = true;
        }

        private void Update()
        {
            CountDown();
            FireEventsWhenTimeReachesZeroThenStopCounting();
        }

        private void CountDown()
        {
            if (ShouldCount())
            {
                _currentTime -= Time.deltaTime;
                UpdateTimerTMP(_currentTime);
            }
        }

        private bool ShouldCount()
        {
            return (_shouldCount && _currentTime > 0);
        }

        private void UpdateTimerTMP(float value)
        {
            _gameTimerTMP.text = TimeFormatter.GetTimeFormated(value);
        }

        private void FireEventsWhenTimeReachesZeroThenStopCounting()
        {
            if (_currentTime <= 0)
            {
                OnTimeEnds?.Invoke();
                _shouldCount = false;
            }
        }
    }
}
