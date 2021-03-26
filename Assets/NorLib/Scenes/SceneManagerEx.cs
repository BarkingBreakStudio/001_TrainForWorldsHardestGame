using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : MonoBehaviour
{

    [SceneNamePicker]
    public string DefaultSceneParamter;

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void LoadSceneAdditive()
    {
        FindObjectOfType<SceneLoader>().LoadScene(DefaultSceneParamter);
        //LoadSceneAdditive(DefaultSceneParamter);
    }

    public static void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public static bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (("Assets/" + sceneName + ".unity") == SceneManager.GetSceneAt(i).path)
            {
                return true;
            }
        }
        return false;
    }
}
