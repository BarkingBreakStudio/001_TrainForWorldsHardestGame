using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMenuUI : MonoBehaviour
{

    public void SetDifficulty(GameManager.Difficulty difficulty)
    {
        var gm = FindObjectOfType<GameManager>();
        if (gm)
        {
            gm.DifficultySelected = difficulty;
        } 
    }

    public void SetDifficultyEasy()
    {
        SetDifficulty(GameManager.Difficulty.Easy);
    }

    public void SetDifficultyMedium()
    {
        SetDifficulty(GameManager.Difficulty.Medium);
    }

    public void SetDifficultyHard()
    {
        SetDifficulty(GameManager.Difficulty.Hard);
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
