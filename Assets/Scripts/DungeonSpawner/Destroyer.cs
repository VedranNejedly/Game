using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        Debug.Log("I collided with spawn point");
        if(other.CompareTag("SpawnPoint")){
            Destroy(other.gameObject);
            Debug.Log("I collided with spawn point");}
    }
}
