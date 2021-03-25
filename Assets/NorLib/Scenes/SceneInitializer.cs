using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        string[] assetNames = AssetDatabase.FindAssets("t:SceneInitializerSO");
        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var asset = AssetDatabase.LoadAssetAtPath<SceneInitializerSO>(SOpath);
            SceneManagerEx.LoadSceneAdditive(asset.PersistentScene);
        }
    }

}
