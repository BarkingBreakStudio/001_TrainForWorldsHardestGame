using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{

    Text scoreText;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gm = FindObjectOfType<GameManager>();
        if(scoreText != null && gm != null)
        {
            scoreText.text = gm.GettPlayerScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
