using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    string alphabet = "qwertzuiopasdfghjklyxcvbnm".ToUpper();

    public TextMesh text;
    public StringFilteredEventListener InputListener;

    // Start is called before the first frame update
    void Start()
    {
        text.text = alphabet.Substring(Random.Range(0, alphabet.Length), 1);
        InputListener.RegexFilter = text.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
