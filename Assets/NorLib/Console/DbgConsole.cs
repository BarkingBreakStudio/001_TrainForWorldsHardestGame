using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbgConsole : MonoBehaviour
{
    public void DebugLog(object msg)
    {
        Debug.Log(msg);
    }

    public void DebugLog(string msg)
    {
        Debug.Log(msg);
    }
}
