using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayLevelManager : MonoBehaviour
{

    [SerializeField]
    private StringEventChannelSO LevelEvents;
    private StringEventListener strEvtListener;

    public UnityEvent OnPlayerDead;

    [Header("Scene Loader")]
    [SerializeField]
    private SceneLoaderSO SceneLoaderChannel;
    private SceneLoaderEventTransmitter sceneLoaderTrans;
    [SerializeField]
    private  SceneLoaderSO.SceneLoaderReqest reloadScene;
    [SerializeField]
    private  SceneLoaderSO.SceneLoaderReqest LoadNextScene;

    enum e_state
    {
        playing,
        gameLost,
        gameWon,
    }

    e_state state = e_state.playing;

    private void Awake()
    {
        strEvtListener = gameObject.AddComponent<StringEventListener>();
        strEvtListener.OnEventRaised.AddListener(LevelEventHappened);
        strEvtListener.SetChannel(LevelEvents);

        sceneLoaderTrans = gameObject.AddComponent<SceneLoaderEventTransmitter>();
        sceneLoaderTrans.SetChannel(SceneLoaderChannel);
    }

    private void LevelEventHappened(string evt)
    {
        switch (evt)
        {
            case "PlayerDead":
                if(state == e_state.playing)
                {
                    state = e_state.gameLost;
                    OnPlayerDead.Invoke();
                    sceneLoaderTrans.TransmitEvent(reloadScene);
                }
                break;
            case "PlayerGoal":
                if (state == e_state.playing)
                {
                    state = e_state.gameWon;
                    sceneLoaderTrans.TransmitEvent(LoadNextScene);
                }
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
