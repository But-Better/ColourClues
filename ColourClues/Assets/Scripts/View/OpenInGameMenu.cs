using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

public class OpenInGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private KeysDto KeysDto;

    [field: SerializeField] private GameObject view;

    [field: SerializeField] private GameObject loadGameObject;

    private LoadMode _loadMode;

    private bool _isPause = false;

    private void Start()
    {
        _loadMode = loadGameObject.GetComponent<LoadMode>();
        KeysDto = _loadMode.GetLoadedData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            KeysDto = _loadMode.GetLoadedData();
        }

        Debug.Log("CODe: " + string.Compare(KeysDto.TextPause, "P", StringComparison.Ordinal));
        if (!Input.GetKeyDown(KeysDto.TextPause.ToLower())) return;

        _isPause = !_isPause;
        Time.timeScale = _isPause ? 0 : 1;
        view.SetActive(_isPause);
    }
}