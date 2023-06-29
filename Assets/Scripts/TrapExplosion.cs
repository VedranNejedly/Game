using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapExplosion : MonoBehaviour
{

    public GameObject exposionOne,exposionTwo,bombOne,bombTwo,laser;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other){
        if(other.tag=="Player" || other.tag=="Enemy"){
            laser.SetActive(false);
            bombOne.SetActive(false);
            bombTwo.SetActive(false);
            exposionOne.SetActive(true);
            exposionTwo.SetActive(true);
            StartCoroutine(DestroyExplosionTrap());
        }
    }

    IEnumerator DestroyExplosionTrap(){
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
        
    }
}

