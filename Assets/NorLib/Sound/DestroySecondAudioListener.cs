using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySecondAudioListener : MonoBehaviour
{
    private void Awake()
    {
        var audioListeners = FindObjectsOfType<AudioListener>();
        if (audioListeners.Length > 1)
        {
            var myListener = GetComponent<AudioListener>();
            if (myListener != null)
            {
                Destroy(myListener);
            }
        }
    }
}
