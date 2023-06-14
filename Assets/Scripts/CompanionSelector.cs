using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CompanionSelector : MonoBehaviour
{

    public ValueHolder val;
    public RunStats runStats;

    int currentCompanion = 0;

    private void SelectCompanion(int index){
        if(index > transform.childCount-1) {
            currentCompanion = 0;
            index = 0;
            }
        if(index<0){
            index = transform.childCount-1;
            currentCompanion = transform.childCount-1;
        }
        for(int i = 0;i<transform.childCount;i++){
            this.transform.GetChild(i).gameObject.SetActive(i == index);
            if(i==index){
                val.storeValue(i);
            }
        }
    }

    public void ChangeCompanion(int change){
        currentCompanion += change;
        Debug.Log(currentCompanion);
        SelectCompanion(currentCompanion); 
    }

      public void StartGame(){
        //Load next scene in the build manager
        runStats.StartARun();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

}
