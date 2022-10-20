using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DGMKCollections.Timer
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class NumericMSFTimer : Timer
    {
        private TextMeshProUGUI _display;

        void Awake()
        {
            _display = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            _display.text = ToStringFormatted(@"mm\:ss\.fff");
        }
    }
}