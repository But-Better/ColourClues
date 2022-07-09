using System;
using UnityEngine;


public class LevelEditorManagement : MonoBehaviour
{
    private GameObject _canvas;

    private void Start()
    {
        _canvas = GameObject.Find("Canvas").gameObject;
        if (_canvas.scene.isLoaded)
        {
            _canvas.SetActive(true);
        }
    }

    private void Update()
    {

    }
}