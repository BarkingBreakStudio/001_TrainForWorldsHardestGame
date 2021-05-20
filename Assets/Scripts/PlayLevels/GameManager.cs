using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public StringEventChannelSO LevelEvents;
    private StringEventListener LevelEvtListener;


    [Header("Score")]
    public Dictionary<string, float> playerStasts = new Dictionary<string, float>();

    private void Awake()
    {
        LevelEvtListener = StringEventListener.AddComponent(gameObject, LevelEvents, LevelEventHappened);
    }

    private void LevelEventHappened(string evt)
    {
        switch (evt)
        {
            case "PlayerStart":
                LevelTimeWatch watch = FindObjectOfType<LevelTimeWatch>(true);
                PlayLevelManager lvlManager = FindObjectOfType<PlayLevelManager>();
                if (watch != null && lvlManager != null)
                {
                    if (playerStasts.ContainsKey(lvlManager.LevelName))
                    {
                        watch.ElapsedTime = playerStasts[lvlManager.LevelName];
                    }
                    watch.enabled = true;
                }
                break;

            case "PlayerGoal":
            case "PlayerDead":
                watch = FindObjectOfType<LevelTimeWatch>(true);
                lvlManager = FindObjectOfType<PlayLevelManager>();
                if(watch != null && lvlManager != null)
                {
                    playerStasts[lvlManager.LevelName] = watch.ElapsedTime;
                    watch.enabled = false;
                }
                break;
        }
    }

    public string GettPlayerScore()
    {
        string s_score = "";
        foreach (var playerScore in playerStasts)
        {
            s_score += playerScore.Key + " : " + playerScore.Value.ToString("N1") + "s" + Environment.NewLine;
        }
        return s_score;
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
