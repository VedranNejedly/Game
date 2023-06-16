using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RunStatsUI : MonoBehaviour
{
    public RunStats runStats;
    public TMP_Text numberOfRuns;
    public TMP_Text numberOfWins;
    public TMP_Text numberOfLosses;
    public TMP_Text winsInARow;

    void Start()
    {
        numberOfRuns.text = "Total runs :" + runStats.totalRuns.ToString();
        numberOfWins.text = "Total wins : " + runStats.wins.ToString();
        numberOfLosses.text = "Total losses : "+runStats.losses.ToString();
        winsInARow.text = "Wins in a row : "+runStats.winsInARow.ToString();


    }
}
