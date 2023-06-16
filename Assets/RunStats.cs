using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunStats : MonoBehaviour
{

    public int totalRuns;
    public int wins;
    public int losses;
    public int winsInARow;

    void Start()
    {
        totalRuns = PlayerPrefs.GetInt("TotalRuns");
        losses = PlayerPrefs.GetInt("RunLosses");
        wins = PlayerPrefs.GetInt("RunWins");
        winsInARow = PlayerPrefs.GetInt("WinsInARow");

        if(totalRuns != losses + wins){
            losses = totalRuns - wins;
            winsInARow = 0;
            PlayerPrefs.SetInt("WinsInARow",winsInARow);
            PlayerPrefs.SetInt("RunLosses",losses);
        }
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
