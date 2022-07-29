using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Keymapper is deprecate (Test)
/// </summary>
public class KeyMapping : MonoBehaviour
{
    public KeyCode Forward { get; set; } = KeyCode.W;
    public KeyCode Backward { get; set; } = KeyCode.S;
    public KeyCode Left { get; set; } = KeyCode.S;
    public KeyCode Right { get; set; } = KeyCode.D;
    public KeyCode Pause { get; set; } = KeyCode.Escape;
    public KeyCode Emotes { get; set; } = KeyCode.T;

    public void UpdateForward(GameObject key)
    {
        var textMeshPro = key.GetComponent<TextMeshPro>();
        Forward = Enum.Parse<KeyCode>(textMeshPro.text);
        Debug.Log(textMeshPro.text);
    }
    
    public void UpdateBackward(string key)
    {
        Backward = Enum.Parse<KeyCode>(key);
    }
    
    public void UpdateLeft(string key)
    {
        Left = Enum.Parse<KeyCode>(key);
    }
    
    public void UpdateRight(string key)
    {
        Right = Enum.Parse<KeyCode>(key);
    }
    
    public void UpdatePause(string key)
    {
        Pause = Enum.Parse<KeyCode>(key);
    }
    
    public void UpdateEmotes(string key)
    {
        Emotes = Enum.Parse<KeyCode>(key);
    }

    private void Update()
    {
        
    }
}
