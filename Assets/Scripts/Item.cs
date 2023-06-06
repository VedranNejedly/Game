using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string itemName;
    //Funkcija koja na koliziju s igracem dodijeli item vrijednost igraću
    private void OnTriggerStay(Collider other){
        //AKo je gameObject igrac, dohvati komponentu PlayerHealth i uvecaj mu health za healthValue
         if(Input.GetKeyDown(KeyCode.T)){
            if(other.gameObject.tag=="Player"){
                //Added item

                if(itemName == "SwordOfTheHephaestus"){
                    other.gameObject.GetComponent<PlayerAttack>().SwordOfTheHephaestus();
                }
                //Added item

                if(itemName == "SwordOfBetrayal"){
                    other.gameObject.GetComponent<PlayerAttack>().SwordOfBetrayal();
                }
                //Added item

                if(itemName == "SwordOfTheCursed"){
                    other.gameObject.GetComponent<PlayerHealth>().swordCurse();
                    other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(10);
                }
                //Added item

                if(itemName == "ChildsPlaySword"){
                    other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(2);
                }
                //Added item
                if(itemName=="antiTrapBracer"){
                    other.gameObject.GetComponent<PlayerHealth>().antiTrapBracer();
                }
                //Added item
                if(itemName == "SilverHelmet"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(5);
                    // other.gameObject.GetComponent<PlayerHealth>().upadateMaxArmor(10);
                }
                //Added item
                if(itemName == "Apple"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(20);

                }
                //Added items
                if(itemName == "PotionOfStrength"){
                    other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(5);
                }
                //Added item
                if(itemName == "PotionOfMagicPower"){
                    other.gameObject.GetComponent<PlayerAttack>().updateMagicDamage(5);
                }
                //Item added
                if(itemName == "PotionOfCooldown"){
                    other.gameObject.GetComponent<PlayerMagic>().reduceCooldown(3);
                }
                //Added item
                if(itemName == "ForceFieldPower"){
                    other.gameObject.GetComponent<PlayerAttack>().updateCircleDamage(3);

                }
                //Added item
                if(itemName == "PotionOfMagicCircleCooldown"){
                    other.gameObject.GetComponent<PlayerMagic>().reduceForceFieldCooldown(3);

                }
                //Added item
                if(itemName == "PotionOfLifeForceAbsorption"){
                    other.gameObject.GetComponent<PlayerAttack>().lifesteal();
                }
                //Added item
                if(itemName == "MercyOfAGod"){
                    other.gameObject.GetComponent<PlayerHealth>().MercyOfAGod();
                }

                if(itemName == "BootsOfHermes"){
                    other.gameObject.GetComponent<PlayerMovement>().updateMovementSpeed(4);
                }
                //Added item
                if(itemName == "ShieldOfBruised"){
                    other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(10);
                }
                //Added item
                if(itemName == "ShieldOfTheFallen"){
                    other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(5);
                }
                //Added item
                if(itemName == "ShieldOfTheWicked"){
                    other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(20);
                }
                //Added item
                if(itemName == "SupremeAidKit"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(20);
                }
                //Added item
                
                if(itemName == "BasicAidKit"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(5);
                }
                //Added item
                if(itemName == "AdvancedAidKit"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(10);
                }

                if(itemName == "ForgeByBlood"){
                    other.gameObject.GetComponent<PlayerHealth>().ForgeByBlood();
                }
                //Added item
                if(itemName == "BomberSpawner"){
                    other.gameObject.GetComponent<PlayerAttack>().BomberSpawner();
                }

                Destroy(gameObject);
            }
         }
    }
}
