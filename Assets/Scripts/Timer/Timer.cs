using UnityEngine;
using System;
using TMPro;

namespace DGMKCollections.Timer
{
    public class Timer : MonoBehaviour
    {
        private float _millisecondsCount = 0f;
        public float MillisecondsCount => _millisecondsCount;
        
        [SerializeField]
        private float _startingSeconds = 0f;
        [SerializeField]
        private float _endingSeconds = 0f;

        private float _startingMilliseconds => _startingSeconds * 1000f;
        private float _endingMilliseconds => _endingSeconds * 1000f;
        
        [SerializeField]
        private bool _startTimerOnAwake = false;

        [SerializeField]
        private TextMeshProUGUI _tmp;

        private bool _timerOn = false;
        private TimeSpan ts;

        void Awake() 
        {
            if(_startTimerOnAwake) StartTimer();    
        }
        
        public void StartTimer()
        {
            _timerOn = true;
            _millisecondsCount = _startingMilliseconds;
        }
        public void PauseTimer() => _timerOn = false;

        void Update()
        {
            if(_timerOn) 
            {
                _millisecondsCount += (Time.deltaTime * 1000);
                if(_endingMilliseconds > 0f && _millisecondsCount >= _endingMilliseconds)
                {
                    _millisecondsCount = _endingMilliseconds;
                    PauseTimer();
                }
                
                _tmp.text = ToStringFormatted(@"mm\:ss\.fff");
            }
        }

        public void ResetTimer()
        {
            _millisecondsCount = 0f;
        }

        public string ToStringFormatted(string format) // @"mm\:ss\.fff"
        {
            ts = TimeSpan.FromMilliseconds(_millisecondsCount);
            return ts.ToString(format);
        }
    }
}
