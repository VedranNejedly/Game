using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    // public void StartGame(){
    //     //Load next scene in the build manager
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    // }

    public void ExitGame(){
        //Close the application
        Application.Quit();  
    }
}
