using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public int maxHealthValue=0;
    [SerializeField] public int movementSpeedMod=0;
    [SerializeField] public int meeleAttackMod=0;
    [SerializeField] public int magicDamageMod=0;
    [SerializeField] public bool isSwordOfTheCursed=false;
    [SerializeField] public bool lifeForceAbsorption = false;
    [SerializeField] public float magicCooldownRecution = 0;



    //Funkcija koja na koliziju s igracem dodijeli item vrijednost igraću
    private void OnTriggerEnter(Collider other){
        //AKo je gameObject igrac, dohvati komponentu PlayerHealth i uvecaj mu health za healthValue
         if(other.gameObject.tag=="Player"){
            //Update maxHealth igraca
            if(maxHealthValue>0){
                other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(maxHealthValue);
            }
            if(movementSpeedMod>0){
                other.gameObject.GetComponent<PlayerMovement>().updateMovementSpeed(movementSpeedMod);
            }
            if(meeleAttackMod>0){
                other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(meeleAttackMod);
            }
            if(magicDamageMod>0){
                other.gameObject.GetComponent<PlayerAttack>().updateMagicDamage(magicDamageMod);
            }
            
            if(magicCooldownRecution>0){
                other.gameObject.GetComponent<PlayerMagic>().reduceCooldown(magicCooldownRecution);
            }
            
            if(isSwordOfTheCursed){
                other.gameObject.GetComponent<PlayerHealth>().swordCurse();
                other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(99);
            }
            if(lifeForceAbsorption){
                other.gameObject.GetComponent<PlayerAttack>().lifesteal();
            }
            Destroy(gameObject);
         }
    }
}
