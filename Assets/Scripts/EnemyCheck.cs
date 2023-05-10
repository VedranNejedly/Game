using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
        Debug.Log("I collided with an enemy");
        }
    }
    void OnTriggerStay(Collider other){
        if(other.CompareTag("Enemy")){
        Debug.Log("Enemy still here");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Enemy")){
        Debug.Log("No enemies");
        }
    }


}
