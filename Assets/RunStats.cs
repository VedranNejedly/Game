using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunStats : MonoBehaviour
{

    public int totalRuns;
    public int wins;
    public int losses;
    public int winsInARow;

    // Start is called before the first frame update
    // void Awake(){
    //     totalRuns = 0;
    //     wins =0;
    //     losses = 0;
    // }
    void Start()
    {
        totalRuns = PlayerPrefs.GetInt("TotalRuns");
        losses = PlayerPrefs.GetInt("RunLosses");
        wins = PlayerPrefs.GetInt("RunWins");
        winsInARow = PlayerPrefs.GetInt("WinsInARow");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartARun(){
        ++totalRuns;
        PlayerPrefs.SetInt("TotalRuns",totalRuns);
    }

    public void RestartARun(){
        ++losses;
        winsInARow = 0;
        PlayerPrefs.SetInt("WinsInARow",winsInARow);
        PlayerPrefs.SetInt("RunLosses",losses);
        ++totalRuns;
        PlayerPrefs.SetInt("TotalRuns",totalRuns);
    }

    public void QuitARun(){
        ++losses;
        winsInARow = 0;
        PlayerPrefs.SetInt("WinsInARow",winsInARow);
        PlayerPrefs.SetInt("RunLosses",losses);
    }
    
    public void WinARun(){
        ++wins;
        ++winsInARow;
        PlayerPrefs.SetInt("RunWins",wins);
        PlayerPrefs.SetInt("WinsInARow",winsInARow);

    }

    public void LoseARun(){
        ++losses;
        winsInARow = 0;
        PlayerPrefs.SetInt("WinsInARow",winsInARow);
        PlayerPrefs.SetInt("RunLosses",losses);
    }

}
