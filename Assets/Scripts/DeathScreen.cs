using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    private DestroyList dl;
    private RunStats runStats;

    void Start(){
    dl = GameObject.FindGameObjectWithTag("ItemsToDestroy").GetComponent<DestroyList>();
    runStats = GameObject.FindGameObjectWithTag("RunStatsSaver").GetComponent<RunStats>();
    }


    PauseMenu pauseMenu;
    public void RestartGame(){
        dl.DestroyAndReset();
        runStats.RestartARun();
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

}

