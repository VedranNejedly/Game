using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject attackArea;
    public int meeleDamage = 5;
    public int magicDamage = 5;
    public bool lifestealOnHit=false;


    private bool attacking = false;
    float timeToAttack = 0.25f;
    private float timer = 0f;
    // Start is called before the first frame update

    private void Attack(){
        attacking=true;
        attackArea.SetActive(true);
        animator.SetBool("isAttacking",true);

    }


    //Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Attack();
        }
        if(attacking){
            timer += Time.deltaTime;
            if(timer>=timeToAttack){
                timer=0;
                attacking=false;
                attackArea.SetActive(false);
                animator.SetBool("isAttacking",false);

            }
        }
    }


    //ITEMS EFFECTS CODE

    //Funkcija updateMeelePlayerAttack() prima cijelobrojnu varijablu damageMod te pomocu te varijable mijenja meeleDamage igraca
    public void updateMeelePlayerAttack(int damageMod){
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



}
