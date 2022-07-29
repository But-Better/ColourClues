using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace View
{
    /// <summary>
    /// View of pressed keys ingame (not finished)
    /// </summary>
    public class KeyPressedView : MonoBehaviour
    {
        [field: SerializeField] private TextMeshProUGUI forward;
        [field: SerializeField] private TextMeshProUGUI backward;
        [field: SerializeField] private TextMeshProUGUI left;
        [field: SerializeField] private TextMeshProUGUI right;

        private KeysDto _loadMode;

        private void Awake()
        {
            _loadMode = gameObject.AddComponent<LoadMode>().GetLoadedData();
            forward.text = _loadMode.TextForward;
            backward.text = _loadMode.TextBackward;
            left.text = _loadMode.TextLeft;
            right.text = _loadMode.TextRight;
        }
    }
}
