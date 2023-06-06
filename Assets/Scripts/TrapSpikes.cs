using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{
    public int damage;
    public GameObject spikes;
    public Animator trapAnimator;
    bool trapIsActive = true;
    bool trapCanDealDamage = true;

    private void OnTriggerEnter(Collider other){
            if(other.tag=="Player" || other.tag=="Enemy"){
                if(trapIsActive){
                    trapIsActive= false;
                    spikes.SetActive(true);
                    trapAnimator.SetBool("trapIsActive",true);
                    FindObjectOfType<AudioManager>().playSound("SpikesTrap");
                    Invoke("PlayTrapCloseAnimation",2.0f); 
                    trapCanDealDamage = true;
                }
                if(trapCanDealDamage && other.tag =="Player"){
                    if(other.GetComponent<PlayerHealth>().hasAntiTrapBracer == false){
                        other.GetComponent<PlayerHealth>().InflictDamage(damage);
                    }
                }
                if(trapCanDealDamage && other.tag =="Enemy"){
                    other.GetComponent<Enemy>().Damage(damage);
                }
            }
        }

    private void PlayTrapCloseAnimation(){
        trapAnimator.SetBool("trapIsActive",false);
        trapCanDealDamage = false;
        Invoke("ResetTrap",2.0f);
    }   

    private void ResetTrap(){
        spikes.SetActive(false);
        trapIsActive = true;
    }
}
