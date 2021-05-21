using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLevelScore : MonoBehaviour
{

    Text textScore;
    LevelTimeWatch watch;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<Text>();
        watch = FindObjectOfType<LevelTimeWatch>();

        if (textScore)
        {
            textScore.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(textScore!= null && watch != null && watch.ElapsedTime > 0.001f)
        {
            textScore.text = watch.ElapsedTime.ToString("N1") + "s";
        }
    }
}
