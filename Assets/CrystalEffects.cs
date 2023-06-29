using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalEffects : MonoBehaviour
{
    public GameObject crystalLight;

    private bool crystalActivated = false;
    public bool isHealthCrystal;
    public bool isDamageCrystal;
    public bool isPoisonCrystal;
    public bool isDangerousCrystal;
    public bool isMagicCrystal;
    public bool isSpeedCrystal;
    public bool isSlowCrystal;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            if(!crystalActivated){
                crystalActivated = true;
                crystalLight.SetActive(true);
                if(isHealthCrystal){
                    other.GetComponent<PlayerHealth>().upadateMaxHealth(1);
                }
                if(isDangerousCrystal){
                    other.GetComponent<PlayerHealth>().upadateMaxHealth(-2);
                }
                if(isDamageCrystal){
                    other.GetComponent<PlayerAttack>().updateMeelePlayerAttack(1);
                }
                if(isPoisonCrystal){
                    other.GetComponent<PlayerHealth>().tickPoison();
                }
                if(isMagicCrystal){
                    other.GetComponent<PlayerMagic>().reduceForceFieldCooldown(1);
                    other.GetComponent<PlayerMagic>().reduceCooldown(1);
                }
                if(isSpeedCrystal){
                    other.GetComponent<PlayerMovement>().updateMovementSpeed(1);
                }
                if(isSlowCrystal){
                    other.GetComponent<PlayerMovement>().updateMovementSpeed(-1);
                }
            }

        }
    }
}
