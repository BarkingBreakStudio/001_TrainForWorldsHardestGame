using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHighScore : MonoBehaviour
{

    public InputField InputPlayerName;
    public Button ButtonSaveHighscore;


    Text highScoreText;
    GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    private void OnEnable()
    {
        ButtonSaveHighscore?.onClick.AddListener(ButtonSaveHighscore_Clicked);
    }


    private void OnDisable()
    {
        ButtonSaveHighscore?.onClick.RemoveListener(ButtonSaveHighscore_Clicked);
    }

    private void ButtonSaveHighscore_Clicked()
    {
        if(highScoreText && gm && ButtonSaveHighscore)
        {
            if(highScoreText.text != "")
            {
                gm.SaveCurrentStatsInHighScore(InputPlayerName.text);
                ButtonSaveHighscore.transform.parent.gameObject.SetActive(false);
                UpdateText();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void UpdateText()
    {
        highScoreText = GetComponent<Text>();
        gm = FindObjectOfType<GameManager>();
        if (highScoreText != null && gm != null)
        {
            highScoreText.text = gm.GetHighScoreText();
        }
    }

}
