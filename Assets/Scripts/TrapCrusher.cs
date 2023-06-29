using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCrusher : MonoBehaviour
{
    private int trapDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().playSound("TrapSlide");
    }
    
    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            if(other.GetComponent<PlayerHealth>().hasAntiTrapBracer == false){
                other.GetComponent<PlayerHealth>().updateHealth(-trapDamage/2);
            }
        }
        if(other.tag=="Enemy"){
            other.GetComponent<Enemy>().Damage(trapDamage);
        }
    }
}
