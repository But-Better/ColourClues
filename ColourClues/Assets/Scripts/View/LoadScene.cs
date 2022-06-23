using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [field: SerializeField] public string _sceneName;

    void loadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
 