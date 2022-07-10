using System;
using UnityEngine;

namespace View
{
    public class KeysDto
    {
        public string TextForward;
        public string TextBackward;
        public string TextLeft;
        public string TextRight;
        public string TextPause;
        public string TextEmotes;
        public string TextIP;
        
        public KeyCode ToKeyCode(string value)
        {
            return (KeyCode)Enum.Parse(typeof(KeyCode), value);
        }
    }
}