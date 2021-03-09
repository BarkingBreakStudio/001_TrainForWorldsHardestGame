using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        GetComponent<Animator>().SetBool("IsOpen", true);
    }

    public void CloseDoor()
    {
        GetComponent<Animator>().SetBool("IsOpen", false);
    }
}
