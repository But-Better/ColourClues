using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using View;

/// <summary>
/// Save data to Json for player settings
/// </summary>
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
            TextForward = CleanUp(textForward.text),
            TextBackward = CleanUp(textBackward.text),
            TextLeft = CleanUp(textLeft.text),
            TextRight = CleanUp(textRight.text),
            TextPause = CleanUp(textPause.text),
            TextEmotes = CleanUp(textEmotes.text),
            TextIP = CleanUp(textIP.text),
        };
        Debug.Log(newDto.TextBackward);
        Debug.Log(newDto.TextForward);

        SaveData(newDto);
    }

    private string CleanUp(string o)
    {
        var removeNr = o.Replace("\n", "").Replace("\r", "");
        var toChar = removeNr.ToCharArray();
        string newString = null;
        for (var index = 0; index < toChar.Length-1; index++)
        {
            var c = toChar[index];
            newString += c.ToString();
        }
        return newString;
    }

    private void SetPaths()
    {
        Path = Application.dataPath + System.IO.Path.AltDirectorySeparatorChar + "KeysData.json";
        PersistentPath = Application.persistentDataPath + System.IO.Path.AltDirectorySeparatorChar + "KeysData.json";
    }

    private void SaveData(KeysDto dto)
    {
        try
        {
            var code = (KeyCode)Enum.Parse(typeof(KeyCode), dto.TextForward);
            Debug.Log(code);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Debug.Log("Saving Data at " + PersistentPath);
        var json = JsonUtility.ToJson(dto);
        Debug.Log(json);

        using var writer = new StreamWriter(PersistentPath);
        writer.Write(json);
    }
    
}
