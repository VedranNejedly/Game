using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    public int damage = 5;
    private void OnTriggerEnter(Collider other){
        if(other.tag=="Enemy"){
            Debug.Log("Enemy");
            Enemy health = other.GetComponent<Enemy>();
            if(health != null){
                health.Damage(damage);
                Debug.Log(damage);
            }

        }
    }
}
