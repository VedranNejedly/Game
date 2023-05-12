using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDamage : MonoBehaviour
{

    public int magicDamage=10;

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Enemy"){
            Enemy enemyHealth = other.GetComponent<Enemy>();
            if(enemyHealth != null){
                enemyHealth.Damage(magicDamage);
                Debug.Log(magicDamage);
            }
        }
     }
}
