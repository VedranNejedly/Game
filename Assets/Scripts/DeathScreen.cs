using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    PauseMenu pauseMenu;
    public void RestartGame(){
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        //Load next scene in the build manager
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

}
