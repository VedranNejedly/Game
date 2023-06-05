using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // [SerializeField] public int maxHealthValue=0;
    [SerializeField] public string itemName;
    // [SerializeField] public int movementSpeedMod=0;
    // [SerializeField] public int meeleAttackMod=0;
    // [SerializeField] public int magicDamageMod=0;
    // [SerializeField] public bool lifeForceAbsorption = false;
    // [SerializeField] public float magicCooldownRecution = 0;



    //Funkcija koja na koliziju s igracem dodijeli item vrijednost igraću
    private void OnTriggerEnter(Collider other){
        //AKo je gameObject igrac, dohvati komponentu PlayerHealth i uvecaj mu health za healthValue
         if(other.gameObject.tag=="Player"){
            //Update maxHealth igraca
            if(itemName == "SwordOfTheHephaestus"){
                other.gameObject.GetComponent<PlayerAttack>().SwordOfTheHephaestus();
            }

            if(itemName == "SwordOfBetrayal"){
                other.gameObject.GetComponent<PlayerAttack>().SwordOfBetrayal();
            }

            if(itemName == "SwordOfTheCursed"){
                other.gameObject.GetComponent<PlayerHealth>().swordCurse();
                other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(99);
            }

            if(itemName == "ChildsPlaySword"){
                 other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(2);
            }

            if(itemName=="antiTrapVest"){
                other.gameObject.GetComponent<PlayerHealth>().antiTrapVest();
            }

            if(itemName == "SilverHelmet"){
                other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(5);
                // other.gameObject.GetComponent<PlayerHealth>().upadateMaxArmor(10);
            }

            if(itemName == "Apple"){
                other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(20);

            }

            if(itemName == "PotionOfStrength"){
                other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(5);
            }

            if(itemName == "PotionOfMagicPower"){
                other.gameObject.GetComponent<PlayerAttack>().updateMagicDamage(5);
            }

            if(itemName == "PotionOfCooldown"){
                other.gameObject.GetComponent<PlayerMagic>().reduceCooldown(3);
            }

            if(itemName == "ForceFieldPower"){
                other.gameObject.GetComponent<PlayerAttack>().updateCircleDamage(3);

            }
            if(itemName == "ForceFieldCooldown"){
                other.gameObject.GetComponent<PlayerMagic>().reduceForceFieldCooldown(3);

            }

            if(itemName == "lifeForceAbsorption"){
                other.gameObject.GetComponent<PlayerAttack>().lifesteal();
            }

            if(itemName == "MercyOfAGod"){
                other.gameObject.GetComponent<PlayerHealth>().MercyOfAGod();
            }

            if(itemName == "BootsOfHermes"){
                other.gameObject.GetComponent<PlayerMovement>().updateMovementSpeed(4);
            }
            if(itemName == "ArmorOfTheFallen"){
                other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(5);
            }

            if(itemName == "ArmorOfBruised"){
                other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(10);
            }

            if(itemName == "ArmorOfTheWicked"){
                other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(20);
            }

            if(itemName == "SupremeAidKit"){
                other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(20);
            }
            
            if(itemName == "BasicAidKit"){
                other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(5);
            }
            if(itemName == "AdvancedAidKit"){
                other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(10);
            }

            if(itemName == "ForgeByBlood"){
                other.gameObject.GetComponent<PlayerHealth>().ForgeByBlood();
            }

            if(itemName == "BomberSpawner"){
                other.gameObject.GetComponent<PlayerAttack>().BomberSpawner();

            }
            Destroy(gameObject);
         }
    }
}
