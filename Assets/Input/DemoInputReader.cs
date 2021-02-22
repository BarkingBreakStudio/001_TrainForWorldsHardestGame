using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInputReader : MonoBehaviour
{

    [SerializeField]
    private StringEventChannelSO inputChannel;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    struct Key2String
    {
        public KeyCode ekey;
        public string sKey;

        public Key2String(KeyCode ekey, string sKey)
        {
            this.ekey = ekey;
            this.sKey = sKey;
        }

        public Key2String(KeyCode ekey)
        {
            this.ekey = ekey;
            this.sKey = ekey.ToString();
        }

    }

    private Key2String[] keysToListenFor = new Key2String[] { 
        new Key2String(KeyCode.Q), 
        new Key2String(KeyCode.W), 
        new Key2String(KeyCode.E), 
        new Key2String(KeyCode.R),
        new Key2String(KeyCode.T),
        new Key2String(KeyCode.Z),
        new Key2String(KeyCode.U),
        new Key2String(KeyCode.I),
        new Key2String(KeyCode.O),
        new Key2String(KeyCode.P),
        new Key2String(KeyCode.A),
        new Key2String(KeyCode.S),
        new Key2String(KeyCode.D),
        new Key2String(KeyCode.F),
        new Key2String(KeyCode.G),
        new Key2String(KeyCode.H),
        new Key2String(KeyCode.J),
        new Key2String(KeyCode.K),
        new Key2String(KeyCode.L),
        new Key2String(KeyCode.Y),
        new Key2String(KeyCode.X),
        new Key2String(KeyCode.C),
        new Key2String(KeyCode.V),
        new Key2String(KeyCode.B),
        new Key2String(KeyCode.N),
        new Key2String(KeyCode.M),
    };


    void Update()
    {
        foreach (var key in keysToListenFor)
        {
            if (Input.GetKeyDown(key.ekey))
            {
                inputChannel?.RaiseEvent(key.sKey);
            }
        }
    }
}
