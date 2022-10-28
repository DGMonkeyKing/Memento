using UnityEngine;
using System;
using System.Collections;

namespace DGMKCollections.Timer
{
    public abstract class Timer : MonoBehaviour
    {
#region EVENTOS
        public delegate void TimerActions();
        public event TimerActions OnStartTimer;
        public event TimerActions OnStopTimer;
        public event TimerActions OnPauseTimer;
        public event TimerActions OnResumeTimer;
        public event TimerActions OnFinishTimer;
#endregion

        private float _millisecondsCount = 0f;
        public float MillisecondsCount => _millisecondsCount;
        
        [SerializeField]
        private float _startingSeconds = 0f;
        [SerializeField]
        private float _endingSeconds = 0f;

        private float _startingMilliseconds => _startingSeconds * 1000f;
        private float _endingMilliseconds => _endingSeconds * 1000f;

        private static TimeSpan ts;
        private bool _timerOn = false;
        private Coroutine _timerCoroutine = null; 
        
        void OnValidate()
        {
            _startingSeconds = Mathf.Clamp(_startingSeconds, 0, float.MaxValue);
            _endingSeconds = Mathf.Clamp(_endingSeconds, 0, float.MaxValue);
        }

        public void StartTimer()
        {
            if(_timerCoroutine == null)
            {
                _timerOn = true;
                _millisecondsCount = _startingMilliseconds;
                _timerCoroutine = StartCoroutine(RunTimer());

                OnStartTimer?.Invoke();
            }
        }
        public void PauseTimer()
        {
            _timerOn = false;

            OnPauseTimer?.Invoke();
        }
        public void ResumeTimer() 
        {
            _timerOn = true;

            OnResumeTimer?.Invoke();
        }
        public void StopTimer()
        {
            if(_timerCoroutine != null)
            {
                _timerOn = false;
                _millisecondsCount = _startingMilliseconds;
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;

                OnStopTimer?.Invoke();
            }
        }

        private void FinishTimer()
        {
            _timerOn = false;
            _millisecondsCount = _endingMilliseconds;
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;

            OnFinishTimer?.Invoke();
        }

        IEnumerator RunTimer()
        {
            while(true)
            {
                if(_timerOn) 
                {
                    _millisecondsCount += (Time.deltaTime * 1000);
                    
                    if(_startingMilliseconds != _endingMilliseconds &&
                        Mathf.Abs(_startingMilliseconds - _endingMilliseconds) <= 
                        Mathf.Abs(_millisecondsCount - _startingMilliseconds))
                    {
                        FinishTimer();
                    }
                }

                yield return 0;
            }
        }

        protected string ToStringFormatted(string format) // @"mm\:ss\.fff"
        {
            ts = TimeSpan.FromMilliseconds(_millisecondsCount);
            return ts.ToString(format);
        }

        public static string MillisecondsToStringFormatted(float milliseconds, string format)
        {
            ts = TimeSpan.FromMilliseconds(milliseconds);
            return ts.ToString(format);
        }
    }
}
