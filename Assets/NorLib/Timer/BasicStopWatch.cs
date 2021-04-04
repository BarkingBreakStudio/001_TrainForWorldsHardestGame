using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStopWatch : MonoBehaviour
{

    public bool StartOnStart = true;

    [SerializeField]
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        if(!StartOnStart)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public virtual void ResetWatch()
    {
        elapsedTime = 0;
    }

    public float ElapsedTime 
    {
        get
        {
            return elapsedTime;
        }
    } 
}
