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


    


    //Funkcija koja na koliziju s igracem dodijeli item vrijednost igraću
    private void OnTriggerEnter(Collider other){
        //AKo je gameObject igrac, dohvati komponentu PlayerHealth i uvecaj mu health za healthValue
         if(other.gameObject.tag=="Player"){
            //Update maxHealth igraca
            other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(maxHealthValue);
            other.gameObject.GetComponent<PlayerMovement>().updateMovementSpeed(movementSpeedMod);
            other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(meeleAttackMod);
            other.gameObject.GetComponent<PlayerAttack>().updateMagicDamage(magicDamageMod);

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
