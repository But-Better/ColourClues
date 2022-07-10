using System;
using System.IO;
using UnityEngine;

namespace View
{
    public class LoadMode : MonoBehaviour
    {
        private string PersistentPath { get; set; }

        private string Path { get; set; }

        private void SetPaths()
        {
            Path = Application.dataPath + System.IO.Path.AltDirectorySeparatorChar + "KeysData.json";
            PersistentPath = Application.persistentDataPath + System.IO.Path.AltDirectorySeparatorChar + "KeysData.json";
        }

        private void Awake()
        {
            SetPaths();

            if (Path is null)
                Debug.LogError("Path is null");
            
            if (PersistentPath is null)
                Debug.LogError("PersistentPath is null");
        }

        public KeysDto GetLoadedData()
        {
            if (!File.Exists(PersistentPath))
            {
                Debug.LogError("PersistentPath File not exists");
            }
            
            using var reader = new StreamReader(PersistentPath);
            var json = reader.ReadToEnd();
            Debug.Log(json);
            return JsonUtility.FromJson<KeysDto>(json);
        }
    }
}