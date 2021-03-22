using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeSceneMgr : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTouchedObject(string touchedObj)
    {
        switch (touchedObj)
        {
            case "Lava":
            case "FireBall":
                player.GetComponent<Rigidbody>().isKinematic = true;
                SceneManagerEx.ReloadScene();
                break;
        }
    }
}
