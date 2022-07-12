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
    [field: SerializeField] private TextMeshProUGUI textForward;
    [field: SerializeField] private TextMeshProUGUI textBackward;
    [field: SerializeField] private TextMeshProUGUI textLeft;
    [field: SerializeField] private TextMeshProUGUI textRight;
    [field: SerializeField] private TextMeshProUGUI textPause;
    [field: SerializeField] private TextMeshProUGUI textEmotes;
    [field: SerializeField] private TextMeshProUGUI textIP;
    
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
            TextForward = CleanUp(textForward),
            TextBackward = CleanUp(textBackward),
            TextLeft = CleanUp(textLeft),
            TextRight = CleanUp(textRight),
            TextPause = CleanUp(textPause),
            TextEmotes = CleanUp(textEmotes),
            TextIP = CleanUp(textIP),
        };
        Debug.Log(newDto.TextBackward);
        Debug.Log(newDto.TextForward);

        SaveData(newDto);
    }

    private string CleanUp(TextMeshProUGUI o)
    {
        return o.text.Replace("\n", "").Replace("\r", "");
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


}