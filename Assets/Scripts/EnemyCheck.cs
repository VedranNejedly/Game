using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCheck : MonoBehaviour
{
    public bool enemyAlive = false;


    void Start(){
    }

    void OnTriggerStay(Collider other){
        if(other.CompareTag("Enemy")){
            enemyAlive = true;
        }
    }
      void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            enemyAlive = true;
        }
    }
      
  


}
