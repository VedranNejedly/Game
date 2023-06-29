using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RunTimer : MonoBehaviour
{
    public GameObject runTimerUI;
    private float runTimer = 0f;
    private float seconds = 0;
    private float minutes = 0;
    private float hours = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        runTimer += Time.deltaTime;
        hours = Mathf.FloorToInt(runTimer / 3600);

        minutes = Mathf.FloorToInt((runTimer%3600) / 60);
        seconds = Mathf.FloorToInt(runTimer % 60);

        runTimerUI.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}:{2:00}",hours,minutes,seconds);
    }
}

