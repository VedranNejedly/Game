using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject attackArea;
    public int meeleDamage = 5;


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
    public void updateMeelePlayerAttack(int damageMod){
        meeleDamage+=damageMod;
    }

}
