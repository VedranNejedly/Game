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
        // if(hours<1){
        //     if(seconds<10 && minutes <10 ){
        //         runTimerUI.GetComponent<TMP_Text>().text = "00:0"+minutes.ToString()+":0"+ seconds.ToString();
        //     }
        //     else if(seconds > 10 && minutes<10){
        //         runTimerUI.GetComponent<TMP_Text>().text = "00:0"+minutes.ToString()+":"+ seconds.ToString();
        //     }
        //     else if(seconds < 10 && minutes >10){
        //         runTimerUI.GetComponent<TMP_Text>().text = "00:"+minutes.ToString()+":0"+ seconds.ToString();
        //     }
        //     else{
        //         runTimerUI.GetComponent<TMP_Text>().text = "00:" + minutes.ToString()+":"+ seconds.ToString();
        //     }
        // }
        // else if(hours>1 && hours <10){
        //       if(seconds<10 && minutes <10 ){
        //         runTimerUI.GetComponent<TMP_Text>().text = "0"+hours.ToString()+":0"+minutes.ToString()+":0"+ seconds.ToString();
        //     }
        //     else if(seconds > 10 && minutes<10){
        //         runTimerUI.GetComponent<TMP_Text>().text = "0"+hours.ToString()+":0"+minutes.ToString()+":"+ seconds.ToString();
        //     }
        //     else if(seconds < 10 && minutes >10){
        //         runTimerUI.GetComponent<TMP_Text>().text = "0"+hours.ToString()+minutes.ToString()+":0"+ seconds.ToString();
        //     }
        //     else{
        //         runTimerUI.GetComponent<TMP_Text>().text = "0"+hours.ToString() + minutes.ToString()+":"+ seconds.ToString();
        //     }
        // }
        // else{
        //     if(seconds<10 && minutes <10 ){
        //         runTimerUI.GetComponent<TMP_Text>().text = hours.ToString()+":0"+minutes.ToString()+":0"+ seconds.ToString();
        //     }
        //     else if(seconds > 10 && minutes<10){
        //         runTimerUI.GetComponent<TMP_Text>().text = hours.ToString()+":0"+minutes.ToString()+":"+ seconds.ToString();
        //     }
        //     else if(seconds < 10 && minutes >10){
        //         runTimerUI.GetComponent<TMP_Text>().text = hours.ToString()+minutes.ToString()+":0"+ seconds.ToString();
        //     }
        //     else{
        //         runTimerUI.GetComponent<TMP_Text>().text = hours.ToString() + minutes.ToString()+":"+ seconds.ToString();
        //     }
        // }


    }
}
