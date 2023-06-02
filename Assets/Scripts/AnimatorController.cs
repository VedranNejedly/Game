using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorController : MonoBehaviour
{

    public Animator animator;
    Enemy enemy;
    void Start()
    {
        enemy = this.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.isDying){
            playDeathAnimation();
            return;
        }else{
            if(enemy.attacking){
                playAttackAnimation();
            }
            if(!(enemy.attacking)){
                stopAttackAnimation();
            }

            if(enemy.isChasing){
                playRunningAnimation();
            }
            if(!(enemy.isChasing)){
                stopRunningAnimation();
            }

            if(enemy.isTakingDamage){
                playEnemyIsDamagedAnimation();
                Invoke("stopEnemyIsDamagedAnimation",1.0f);
            }
        }


   
    }

    private void playAttackAnimation(){
            animator.SetBool("isAttacking",true);
    }
    private void stopAttackAnimation(){
        animator.SetBool("isAttacking",false);
    }

    private void playRunningAnimation(){
        animator.SetBool("isChasing",true);
    }

    private void stopRunningAnimation(){
        animator.SetBool("isChasing",false);
    }

    private void playDeathAnimation(){
        animator.SetBool("isDying",true);
    }
    private void playEnemyIsDamagedAnimation(){
        animator.SetBool("isTakingDamage",true);
    }
    private void stopEnemyIsDamagedAnimation(){
        enemy.isTakingDamage = false;
        animator.SetBool("isTakingDamage",false);

    }
}

