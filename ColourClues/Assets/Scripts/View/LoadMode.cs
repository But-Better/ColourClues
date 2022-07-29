using System;
using System.IO;
using UnityEngine;

namespace View
{
    /// <summary>
    /// Load from JSON the settings keys
    /// </summary>
    public class LoadMode : MonoBehaviour
    {
        private string PersistentPath { get; set; }

        private string Path { get; set; }

        private DateTime lastTimestampSaved = DateTime.UnixEpoch;
        private KeysDto cachedKeysDto = null;
        
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

            lastTimestampSaved = File.GetLastWriteTime(PersistentPath);
            
            using var reader = new StreamReader(PersistentPath);
            var json = reader.ReadToEnd();
            cachedKeysDto = JsonUtility.FromJson<KeysDto>(json);
        }

        public KeysDto GetLoadedData()
        {
            if (!File.Exists(PersistentPath))
            {
                Debug.LogError("PersistentPath File not exists");
            }
            
            bool changedSinceLastTime = File.GetLastWriteTime(PersistentPath)
                .CompareTo(lastTimestampSaved) > 1;

            if (!changedSinceLastTime)
            {
                return cachedKeysDto;
            }

            using var reader = new StreamReader(PersistentPath);
            var json = reader.ReadToEnd();
            cachedKeysDto = JsonUtility.FromJson<KeysDto>(json);
            
            lastTimestampSaved = File.GetLastWriteTime(PersistentPath);
            return cachedKeysDto;
        }
    }
}
