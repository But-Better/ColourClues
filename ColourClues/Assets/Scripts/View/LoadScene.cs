using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scene via index
/// </summary>
public class LoadScene : MonoBehaviour
{
    public void loadScene(int index)
    {
        Debug.Log("index was loaded");
        SceneManager.LoadScene(index);
    }
}
 
