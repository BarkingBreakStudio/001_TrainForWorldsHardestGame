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



    //Difficulty settings
    public enum Difficulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 3,
    }

    public Difficulty DifficultySelected = Difficulty.Easy;


    //Highscores:
    [Serializable]
    public class HighScoreData : IComparable<HighScoreData>
    {
        public string PlayerName;
        public float TotalTime;
        public Difficulty Difficulty;

        public int CompareTo(HighScoreData other)
        {
            return this.TotalTime.CompareTo(other.TotalTime);
        }
    }


    public List<HighScoreData> HighScoreDataList = new List<HighScoreData>();


    private void Awake()
    {
        LevelEvtListener = StringEventListener.AddComponent(gameObject, LevelEvents, LevelEventHappened);
        HighScoreDataList = SaveSystem.LoadObject<List<HighScoreData>>("HighScoreData") ?? new List<HighScoreData>();
    }

    private void LevelEventHappened(string evt)
    {
        switch (evt)
        {
            case "NewGame":
                playerStasts = new Dictionary<string, float>();
                Debug.Log("NewGame");

                break;
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

                foreach (var difScaler in FindObjectsOfType<DifficultyScaler>())
                {
                    difScaler.CallDifficultyActions(DifficultySelected);
                }

                break;

            case "PlayerGoal":
            case "PlayerDead":
                watch = FindObjectOfType<LevelTimeWatch>(true);
                lvlManager = FindObjectOfType<PlayLevelManager>();
                if(watch != null && lvlManager != null && (evt == "PlayerDead" || GameObject.FindGameObjectWithTag("Coin") == null))
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
        s_score += "total" + " : " + CalcPlayerStastsTotal().ToString("N1") + "s" + Environment.NewLine;
        foreach (var playerScore in playerStasts)
        {
            s_score += playerScore.Key + " : " + playerScore.Value.ToString("N1") + "s" + Environment.NewLine;
        }
        return s_score;
    }

    public void SaveCurrentStatsInHighScore(string playername)
    {
        HighScoreDataList.Add(new HighScoreData() { PlayerName = playername , Difficulty = DifficultySelected, TotalTime = CalcPlayerStastsTotal() });
        SaveSystem.SaveObject<List<HighScoreData>>("HighScoreData", HighScoreDataList);
    }

    [ContextMenu("DeleteHighScore")]
    public void DeleteHighScore()
    {
        HighScoreDataList = new List<HighScoreData>();
        SaveSystem.SaveObject<List<HighScoreData>>("HighScoreData", HighScoreDataList);
    }

    public float CalcPlayerStastsTotal()
    {
        float total = 0;
        foreach (var stat in playerStasts.Values)
        {
            total += stat;
        }
        return total;
    }


    public string GetHighScoreText()
    {
        string s_hscore = "";
        HighScoreDataList.Sort(); //sort high scores by time
        foreach (var ScoreDate in HighScoreDataList)
        {
            if(ScoreDate.Difficulty == DifficultySelected)
            {
                s_hscore += ScoreDate.PlayerName + " : " + ScoreDate.TotalTime.ToString("N1") + "s" + Environment.NewLine;
            }
            
        }

        if(s_hscore != "")
        {
            return s_hscore;
        }
        else
        {
            return "add yourself to the list";
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
