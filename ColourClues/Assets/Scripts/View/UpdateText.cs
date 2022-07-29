﻿using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Upate IP address has changed there input
/// </summary>
namespace View
{
    public class UpdateText : MonoBehaviour
    {
        [field: SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        public void UpdateIPText()
        {
            var load = gameObject.AddComponent<LoadMode>();
            var data = load.GetLoadedData();
            _textMeshProUGUI.text = "IP: " + data.TextIP ?? "No Address";
        }

        private void Start()
        {
            UpdateIPText();
        }
    }
}
