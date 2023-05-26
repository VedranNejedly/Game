using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class MagicUI : MonoBehaviour
{


    public Slider magicAttackCooldown;
    public Slider magicFieldCooldown;
    private float attackMagicTimer;
    private float magicFieldTimer;
    PlayerMagic playerMagic;
    // Start is called before the first frame update
    void Start()
    {
       playerMagic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMagic>();
       magicAttackCooldown.maxValue = (float)playerMagic.castCooldownInSeconds;
       magicFieldCooldown.maxValue = (float)playerMagic.magicCircleCooldown;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(!(playerMagic.canCast) && attackMagicTimer>=0){
            attackMagicTimer -= Time.deltaTime;
            magicAttackCooldown.value = attackMagicTimer;
        }else{
            magicAttackCooldown.value = playerMagic.castCooldownInSeconds;
            attackMagicTimer = magicAttackCooldown.maxValue;
        }
        if(!(playerMagic.canCastMagicCircle)){
            magicFieldTimer -=Time.deltaTime;
            magicFieldCooldown.value = magicFieldTimer;

        }else{
            magicFieldCooldown.value = playerMagic.magicCircleCooldown;
            magicFieldTimer = magicFieldCooldown.maxValue;

        }
        // magicAttackCooldown.value = playerMagic.castCooldownInSeconds;
        // magicFieldCooldown.value = playerMagic.magicCircleCooldown;

        
    }
}
