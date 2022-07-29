using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Exit program
/// </summary>
public class ExitMode : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Exit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
