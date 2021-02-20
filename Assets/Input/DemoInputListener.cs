using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInputListener : MonoBehaviour
{

    [SerializeField]
    StringEventChannelSO inputChannel;

    StringEventListener inputListener;
    
    // Start is called before the first frame update
    void Awake()
    {
        inputListener = gameObject.AddComponent<StringEventListener>();
        inputListener.SetChannel(inputChannel);
    }

    private void OnEnable()
    {
        inputListener.OnEventRaised.AddListener(InputHappened);
    }

    private void OnDisable()
    {
        inputListener.OnEventRaised.RemoveListener(InputHappened);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InputHappened(string value)
    {
        Debug.Log("InputHappened: " + value);
    }
}
