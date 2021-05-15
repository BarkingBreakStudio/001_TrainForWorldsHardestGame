using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystemTestUI : MonoBehaviour
{

    public InputField txtTestString;
    public Text lblTestString;

    public Button btnSaveString;
    public Button btnLoadString;


    [Serializable]
    [DataContract]
    public class TestClass
    {
        [DataMember]
        public string str1;
        [DataMember]
        public string str2;
        [DataMember]
        public string str3;
        [DataMember]
        public Vector3 vec1;

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
        }
    }

    public TestClass testClassIn;
    public TestClass testClassOut;

    public string SaveGame;

    public string[] AllSaveGames;

    // Start is called before the first frame update
    private void OnEnable()
    {
        btnSaveString.onClick.AddListener(saveStringBtnPressed);
        btnLoadString.onClick.AddListener(loadStringBtnPressed);

        AllSaveGames = SaveSystem.GetAvailableSaveGames();
    }

    private void OnDisable()
    {
        btnSaveString.onClick.RemoveListener(saveStringBtnPressed);
        btnLoadString.onClick.RemoveListener(loadStringBtnPressed);
    }

    private void loadStringBtnPressed()
    {
       lblTestString.text = SaveSystem.LoadObject<string>("simpleString", SaveGame);
    }

    private void saveStringBtnPressed()
    {
        SaveSystem.SaveObject<string>("simpleString", txtTestString.text, SaveGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [ContextMenu("SaveObject")]
    public void SaveStruct()
    {
        SaveSystem.SaveObject<TestClass>("TestClass", testClassIn, SaveGame);
    }

    [ContextMenu("LoadObject")]
    public void LoadStruct()
    {
       testClassOut =  SaveSystem.LoadObject<TestClass>("TestClass", SaveGame);
    }



}
