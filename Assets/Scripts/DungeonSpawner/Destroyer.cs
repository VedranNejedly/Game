using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.tag =="SpawnPoint"){
            Debug.Log("Colided with other spawn point");
            Destroy(other.gameObject);
            }
    }
}
