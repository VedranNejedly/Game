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

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player"){
            other.GetComponent<PlayerHealth>().updateHealth(-trapDamage/2);
        }
        if(other.tag=="Enemy"){
            other.GetComponent<Enemy>().Damage(trapDamage);
        }
    }
}
