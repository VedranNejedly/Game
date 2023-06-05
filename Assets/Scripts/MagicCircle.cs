using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public int magicCircleDamage;

    // Start is called before the first frame update
    void Start()
    {
        magicCircleDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().magicCircleDmg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag=="Enemy"){
            Enemy enemyHealth = other.GetComponent<Enemy>();
            if(enemyHealth != null){
                // health.Damage(damage);
                enemyHealth.Damage(magicCircleDamage);
            }
        }
    }
}
