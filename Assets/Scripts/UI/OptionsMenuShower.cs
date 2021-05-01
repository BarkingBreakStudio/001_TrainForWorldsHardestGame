using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuShower : MonoBehaviour
{

    public GameObject MenuPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu()
    {
        Instantiate(MenuPrefab);
    }
}
