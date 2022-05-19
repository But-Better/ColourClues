using System;
using UnityEngine;
using Color = System.Drawing.Color;

namespace DefaultNamespace {
    [CreateAssetMenu(menuName = "ScriptableObjects/Color")]
    public class ColorClue : ScriptableObject {
        [SerializeField] private Color32 color;
        [SerializeField] private string colorName;

        public Color32 Color => color;
        public string ColorName => colorName;
    }
}