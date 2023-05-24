using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDamage : MonoBehaviour
{

    public int magicDamage=10;
    // public GameObject explosion;


    private void OnTriggerEnter(Collider other){
        if(other.tag=="Enemy"){
            Enemy enemyHealth = other.GetComponent<Enemy>();
            // explosion.SetActive(true);
            if(enemyHealth != null){
                enemyHealth.Damage(magicDamage);
            }
            StartCoroutine(DestroyGameObject());
        }
     }

        public IEnumerator DestroyGameObject(){
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);

    }
}
