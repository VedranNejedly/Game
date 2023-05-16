using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextLevel : MonoBehaviour
{

    private bool nextLevelTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nextLevelTrigger){
            Debug.Log("I can trigger next level");
        }
    }

    public void canTriggerNextLevel(){
        nextLevelTrigger = true;
    }
}
