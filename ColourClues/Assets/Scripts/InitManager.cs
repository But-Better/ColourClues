using System;
using System.IO;
using UnityEngine;
using View;

namespace DefaultNamespace
{
    public class InitManager : MonoBehaviour
    {
        private string PersistentPath { get; set; }

        private string Path { get; set; }

        private void SetPaths()
        {
            Path = Application.dataPath + System.IO.Path.AltDirectorySeparatorChar + "KeysData.json";
            PersistentPath = Application.persistentDataPath + System.IO.Path.AltDirectorySeparatorChar +
                             "KeysData.json";
        }

        private void Awake()
        {
            SetPaths();

            if (Path is null)
                Debug.LogError("Path is null");

            if (PersistentPath is null)
                Debug.LogError("PersistentPath is null");
        }

        private void Start()
        {
            if (File.Exists(PersistentPath))
            {
                return;
            }

            var newDto = new KeysDto
            {
                TextForward = "w",
                TextBackward = "s",
                TextLeft = "a",
                TextRight = "d",
                TextPause = "p",
                TextEmotes = "e",
                TextIP = "localhost",
            };

            File.Create(PersistentPath);
            var json = JsonUtility.ToJson(newDto);
            File.WriteAllTextAsync(PersistentPath, json);
        }
    }
}