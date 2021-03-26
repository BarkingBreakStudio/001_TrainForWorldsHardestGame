using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public SceneInitializerSO SceneInitSettings;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        List<string> ScenesToDesroy = new List<string>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene curScene = SceneManager.GetSceneAt(i);
            if(curScene.path != ("Assets/" + SceneInitSettings.PersistentScene + ".unity"))
            {
                ScenesToDesroy.Add(curScene.name);
            }
        }

        foreach (var scene in ScenesToDesroy)
        {
            SceneManager.UnloadScene(scene);
        }

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }


}
