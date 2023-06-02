using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    int softControl = 0;
    void Start(){
        FindObjectOfType<AudioManager>().playSound("ExplosionTrap");
    }

    public void OnTriggerEnter(Collider other){
        if(other.tag=="Player" && softControl==0){
            ++softControl;
            other.GetComponent<PlayerHealth>().InflictDamage(5);
        }
        if(other.tag=="Enemy"){
            other.GetComponent<Enemy>().Damage(5);
        }
    }
}
