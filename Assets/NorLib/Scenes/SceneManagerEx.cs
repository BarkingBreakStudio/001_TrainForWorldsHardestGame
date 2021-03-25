using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoBehaviour
{

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void LoadScene(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public static void LoadSceneAdditive(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
    }

    public static bool IsSceneLoaded(SceneAsset scene)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneByName(scene.name) == SceneManager.GetSceneAt(i))
            {
                return true;
            }
        }
        return false;
    }
}
