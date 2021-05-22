using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyScaler : MonoBehaviour
{
    [System.Serializable]
    public class Action
    {
        public GameManager.Difficulty Difficulty;
        public UnityEvent Event;
    }

    //Called by GameManager
    public List<Action> DifficultyActions;

    public void CallDifficultyActions(GameManager.Difficulty difficulty)
    {
        if(DifficultyActions != null)
        {
            foreach (var action in DifficultyActions)
            {
                if(action.Difficulty == difficulty)
                {
                    action.Event.Invoke();
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
