using System;
using TMPro;
using UnityEngine;

namespace View
{
    public class UpdateText : MonoBehaviour
    {
        [field: SerializeField] private TextMeshProUGUI _textMeshProUGUI;

        private void Start()
        {
            var load = gameObject.AddComponent<LoadMode>();
            var data = load.GetLoadedData();
            _textMeshProUGUI.text = "IP: " + data.TextIP ?? "No Address";
        }
    }
}