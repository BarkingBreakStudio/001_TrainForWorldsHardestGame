using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public SceneInitializerSO SceneInitSettings;

    public SceneLoaderSO SceneLoaderRequestChannel;
    private SceneLoaderEventListener SceneLoaderListerner;


    // Start is called before the first frame update
    void Start()
    {
        var slel = gameObject.AddComponent<SceneLoaderEventListener>();
        slel.OnEventRaised.AddListener(onLoaderReqest);
        slel.SetChannel(SceneLoaderRequestChannel);
    }

    private void onLoaderReqest(SceneLoaderSO.SceneLoaderReqest request)
    {
        switch (request.reqType)
        {
            case SceneLoaderSO.ReqType.loadScene:
                LoadScene(request.scene);
            break;
        }
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
            if(curScene.path != SceneInitSettings.PersistentScene)
            {
                ScenesToDesroy.Add(curScene.name);
            }
        }

        foreach (var scene in ScenesToDesroy)
        {
            SceneManager.UnloadSceneAsync(scene);
        }

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }


}
