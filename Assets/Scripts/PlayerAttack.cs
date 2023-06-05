using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject attackArea;
    public int meeleDamage = 5;
    public int magicDamage = 5;
    public int magicCircleDmg = 1;
    public bool lifestealOnHit=false;
    public bool companionDamageBoost = false;
    public bool hasSwordOfTheHephaestus = false;
    public bool hasSwordOfBetrayal = false;

    public GameObject fireOfTheHephaestus;
    // public bool enemyIsInRange = false;
    public EnemySpawnAndKillCount esakc;


    private float soundTimer = 0f;


    private bool attacking = false;
    public float timeToAttack = 1.0f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start(){
        if(companionDamageBoost){
            meeleDamage*=2;
        }
    }



    private void Attack(){
        attacking=true;
        // attackArea.SetActive(true);
        attackArea.GetComponent<BoxCollider>().enabled = true;

        animator.SetBool("isAttacking",true);

    }


    //Update is called once per frame
    void Update()
    {   

        if(soundTimer>=0){
            soundTimer-=Time.deltaTime;
        }
        
        if (Input.GetMouseButtonDown(0)){
            if(!(this.GetComponent<PlayerBlock>().playerIsBlocking)){
                Attack();
            }
        }
        
        if(attacking){
            // if(enemyIsInRange && soundTimer<0 && !esakc.checkIfAllKilled()){
                // FindObjectOfType<AudioManager>().playSound("SwordSlashAndHit");  
                // enemyIsInRange = false;
                // soundTimer=1.0f;

            // }
            // if(!enemyIsInRange && soundTimer<0){
                // FindObjectOfType<AudioManager>().playSound("SwordSwingNoHit");
                // soundTimer=1.0f;


            // }
                // FindObjectOfType<AudioManager>().playSound("SwordSwingNoHit");
                // FindObjectOfType<AudioManager>().playSound("SwordSlashAndHit");  
            timer += Time.deltaTime;
            if(timer>=timeToAttack){
                timer=0;
                attacking=false;
                attackArea.GetComponent<BoxCollider>().enabled= false;

                // attackArea.SetActive(false);
                animator.SetBool("isAttacking",false);

            }
        }
    }

    


    // private void OnCollisionEnter(Collision other){
    //     if(other.gameObject.tag=="Enemy"){
    //         enemyIsInRange = true;
    //         }
    // }

    // private void OnCollisionStay(Collision other){
    //   if(other.gameObject.tag=="Enemy"){
    //         enemyIsInRange = true;
    //         }
    // }
    //   private void OnCollisionExit(Collision other){
    //   if(other.gameObject.tag=="Enemy"){
    //         enemyIsInRange = false;
    //         }
    // }

    // private void OnTriggerEnter(Collider other){
    //     if(other.tag=="Enemy"){
    //         enemyIsInRange = true;
    //         }
    //     }
    // private void OnTriggerStay(Collider other){
    //     if(other.tag=="Enemy"){
    //         enemyIsInRange = true;
    //         }
    //     }
    // private void OnTriggerExit(Collider other){
    //     if(other.tag=="Enemy"){
    //         enemyIsInRange = false;
    //         }
    //     }

    //ITEMS EFFECTS CODE

    //Funkcija updateMeelePlayerAttack() prima cijelobrojnu varijablu damageMod te pomocu te varijable mijenja meeleDamage igraca
    public void updateMeelePlayerAttack(int damageMod){
        if(companionDamageBoost){
            meeleDamage=meeleDamage + damageMod*2;
        }
        meeleDamage+=damageMod;
    }
    //Funkcija lifesteal() postavlja vrijednost varijable lifestealOnHit u true.
    //Ta varijabla se koristi kod napada igraca te ukoliko je istinita igrac ce dobiti hp nazad na stavi udarac
    public void lifesteal(){
        lifestealOnHit=true;
    }
    //Funkfija updateMagicDamage prima cijelobrojnu vrijednost te pomocu te varijable mijenja magicDamage igraca.
    //magicDamage varijabla se koristi za ranged napade odnosno fireball"
    public void updateMagicDamage(int magicDamageMod){
        magicDamage+=magicDamageMod;
    }

    public void updateCircleDamage(int damageMod){
        magicCircleDmg+=damageMod;
    }


    public void SwordOfTheHephaestus(){
        //Fire sword
        hasSwordOfTheHephaestus = true;
        fireOfTheHephaestus.SetActive(true);
    }

    public void SwordOfBetrayal(){
        hasSwordOfBetrayal = true;
    }

    //COMPANION EFFECTS

    public void enableCompanionDamageBoost(){
        companionDamageBoost=true;
    }


}
