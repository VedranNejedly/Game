using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    private DestroyList dl;

    void Start(){
    dl = GameObject.FindGameObjectWithTag("ItemsToDestroy").GetComponent<DestroyList>();
    }


    PauseMenu pauseMenu;
    public void RestartGame(){
        for(int i=0;i<dl.itemsToDestroy.Count;i++){
            if(dl.itemsToDestroy[i].name!= "ValueHolder"){
                Destroy(dl.itemsToDestroy[i]);
            }
        }
        Destroy(dl.gameObject);
        //Load next scene in the build manager
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

}
