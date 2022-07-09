using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManagement : MonoBehaviour
{
    private const string Path = "Assets/Scences/";

    private List<GameObject> _sceneGameObjects = new();

    private GameObject Canvas;

    private const string LevelEditor = "LevelEditor";
    private const string TutorialEditor = "TutorialEditor";
    private const string SettingsEditor = "SettingsEditor";

    private void Start()
    {
        Canvas = GameObject.Find("Canvas").gameObject;
        for (var i = 0; i < Canvas.transform.childCount; i++)
        {
            var can = Canvas.transform.GetChild(i).gameObject;
            _sceneGameObjects.Add(can);
        }

        foreach (var o in _sceneGameObjects)
        {
            switch (o.name)
            {
                case "Exit":
                    var exitBtn = o.GetComponent<Button>();
                    exitBtn.onClick.AddListener(Exit);
                    break;
                case "Settings":
                    var settingsBtn = o.GetComponent<Button>();
                    settingsBtn.onClick.AddListener(Setting);
                    break;
                case "Tutorial":
                    var tutorialBtn = o.GetComponent<Button>();
                    tutorialBtn.onClick.AddListener(Tutorial);
                    break;
                case "Start":
                    var startBtn = o.GetComponent<Button>();
                    startBtn.onClick.AddListener(StartLevelMenu);
                    break;
            }
        }
    }

    private void StartLevelMenu()
    {
        loadScene(LevelEditor);
    }

    private void Tutorial()
    {
        loadScene(TutorialEditor);
    }

    private void Setting()
    {
        loadScene(SettingsEditor);
    }

    private void loadScene(string name)
    {
        var scene = SceneManager.GetSceneByName(name).name;
        Debug.Log(scene);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private void Exit()
    {
        Debug.Log("Exit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}