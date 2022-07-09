using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using View;

public class SaveMode : MonoBehaviour
{
    [field: SerializeField] private GameObject textForward;
    [field: SerializeField] private GameObject textBackward;
    [field: SerializeField] private GameObject textLeft;
    [field: SerializeField] private GameObject textRight;
    [field: SerializeField] private GameObject textPause;
    [field: SerializeField] private GameObject textEmotes;

    private string PersistentPath { get; set; }

    private string Path { get; set; }

    private void Start()
    {
        SetPaths();
    }

    public void Save()
    {
        var newDto = new KeysDto
        {
            TextForward = GetTextFromInput(textForward),
            TextBackward = GetTextFromInput(textBackward),
            TextLeft = GetTextFromInput(textLeft),
            TextRight = GetTextFromInput(textRight),
            TextPause = GetTextFromInput(textPause),
            TextEmotes = GetTextFromInput(textEmotes)
        };
        Debug.Log(newDto.TextBackward);
        Debug.Log(newDto.TextForward);
        
        SaveData(newDto);
    }
    
    private string GetTextFromInput(GameObject o)
    {
        var text = o.GetComponent<TextMeshProUGUI>();
        return text.text.Replace("\n", "").Replace("\r", "");
    }
    
    private void SetPaths()
    {
        Path = Application.dataPath + System.IO.Path.AltDirectorySeparatorChar + "KeysData.json";
        PersistentPath = Application.persistentDataPath + System.IO.Path.AltDirectorySeparatorChar + "KeysData.json";
    }

    private void SaveData(KeysDto dto)
    {
        Debug.Log("Saving Data at " + PersistentPath);
        var json = JsonUtility.ToJson(dto);
        Debug.Log(json);

        using var writer = new StreamWriter(PersistentPath);
        writer.Write(json);
    }

    public void LoadData()
    {
        using var reader = new StreamReader(PersistentPath);
        var json = reader.ReadToEnd();

        var data = JsonUtility.FromJson<KeysDto>(json);
        Debug.Log(data.ToString());
    }
    
}