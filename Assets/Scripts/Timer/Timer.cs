using UnityEngine;
using TMPro;
using System;

namespace DGMKCollections.Timer
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Timer : MonoBehaviour
    {
        private float _milliseconds = 0f;

        [SerializeField]
        private bool _timerOn = false;

        private TextMeshProUGUI _tmp;
        private TimeSpan ts;

        private void Awake() 
        {   
            _tmp = GetComponent<TextMeshProUGUI>();
        }
        
        // Start is called before the first frame update
        void StartTimer()
        {
            _timerOn = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(_timerOn)
            {
                _milliseconds += (Time.deltaTime * 1000);
                ts = TimeSpan.FromMilliseconds(_milliseconds);
                _tmp.text = ts.ToString(@"mm\:ss\.fff");
            }
        }

        void ResetTimer()
        {
            _milliseconds = 0f;
        }
    }
}