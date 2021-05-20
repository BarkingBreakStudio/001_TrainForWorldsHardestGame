using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLevelScore : MonoBehaviour
{

    Text textScore;
    LevelTimeWatch watch;

    public string text;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<Text>();
        watch = FindObjectOfType<LevelTimeWatch>();

        text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if(textScore!= null && watch != null)
        {
            textScore.text = watch.ElapsedTime.ToString("N1") + "s";
        }
    }
}
