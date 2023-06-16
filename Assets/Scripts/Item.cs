using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Transform player;
    private AudioManager audioManager;
    void Start(){
        player = GameObject.Find("Player").GetComponent<Transform>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update(){
        transform.LookAt(player);
    }
    [SerializeField] public string itemName;
    //Funkcija koja na koliziju s igracem dodijeli item vrijednost igraću
    private void OnTriggerStay(Collider other){
        //AKo je gameObject igrac, dohvati komponentu PlayerHealth i uvecaj mu health za healthValue
         if(Input.GetKeyDown(KeyCode.T)){
            if(other.gameObject.tag=="Player"){
                //Added item

                if(itemName == "SwordOfTheHephaestus"){
                    other.gameObject.GetComponent<PlayerAttack>().SwordOfTheHephaestus();
                    audioManager.playSound("ThisWillBurn");
                }
                //Added item

                if(itemName == "SwordOfBetrayal"){
                    other.gameObject.GetComponent<PlayerAttack>().SwordOfBetrayal();
                    audioManager.playSound("SwordOfBetrayal");

                }

                if(itemName == "SwordOfTheCursed"){
                    other.gameObject.GetComponent<PlayerHealth>().swordCurse();
                    other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(10);
                    audioManager.playSound("SwordOfTheCursed");

                }
                //Added item

                if(itemName == "ChildsPlaySword"){
                    other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(2);
                    audioManager.playSound("WhyAmIGivenToys");

                }
                //Added item
                if(itemName=="antiTrapBracer"){
                    other.gameObject.GetComponent<PlayerHealth>().antiTrapBracer();
                    audioManager.playSound("AntiTrapBracer");

                }
                //Added item
                if(itemName == "SilverHelmet"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(5);
                    audioManager.playSound("SilverHelmet");

                    // other.gameObject.GetComponent<PlayerHealth>().upadateMaxArmor(10);
                }
                //Added item
                if(itemName == "Apple"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(20);
                    audioManager.playSound("Apple");


                }
                //Added items
                if(itemName == "PotionOfStrength"){
                    other.gameObject.GetComponent<PlayerAttack>().updateMeelePlayerAttack(5);
                    audioManager.playSound("PotionPickup");

                }
                //Added item
                if(itemName == "PotionOfMagicPower"){
                    other.gameObject.GetComponent<PlayerAttack>().updateMagicDamage(5);
                    audioManager.playSound("PotionPickup");

                }
                //Item added
                if(itemName == "PotionOfCooldown"){
                    other.gameObject.GetComponent<PlayerMagic>().reduceCooldown(3);
                    audioManager.playSound("PotionPickup");

                }
                //Added item
                if(itemName == "ForceFieldPower"){
                    other.gameObject.GetComponent<PlayerAttack>().updateCircleDamage(3);
                    audioManager.playSound("ItemPickup");


                }
                //Added item
                if(itemName == "PotionOfMagicCircleCooldown"){
                    other.gameObject.GetComponent<PlayerMagic>().reduceForceFieldCooldown(3);
                    audioManager.playSound("ItemPickup1");

                    

                }
                //Added item
                if(itemName == "PotionOfLifeForceAbsorption"){
                    other.gameObject.GetComponent<PlayerAttack>().lifesteal();
                    audioManager.playSound("PotionPickup");

                }
                //Added item
                if(itemName == "MercyOfAGod"){
                    other.gameObject.GetComponent<PlayerHealth>().MercyOfAGod();
                    audioManager.playSound("MercyOfAGod");

                }
                //Added item
                if(itemName == "BootsOfHermes"){
                    other.gameObject.GetComponent<PlayerMovement>().updateMovementSpeed(4);
                    audioManager.playSound("BootsOfHermes");

                }
                //Added item
                if(itemName == "ShieldOfBruised"){
                    other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(10);
                    audioManager.playSound("MoreArmor");
                    
                }
                //Added item
                if(itemName == "ShieldOfTheFallen"){
                    other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(5);
                    audioManager.playSound("MoreArmor");

                }
                //Added item
                if(itemName == "ShieldOfTheWicked"){
                    other.gameObject.GetComponent<PlayerHealth>().UpdateMaxArmor(20);
                    audioManager.playSound("MoreArmor");

                }
                //Added item
                if(itemName == "SupremeAidKit"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(20);
                    audioManager.playSound("AidKit");

                }
                //Added item
                
                if(itemName == "BasicAidKit"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(5);
                    audioManager.playSound("AidKit");

                }
                //Added item
                if(itemName == "AdvancedAidKit"){
                    other.gameObject.GetComponent<PlayerHealth>().upadateMaxHealth(10);
                    audioManager.playSound("AidKit");

                }

                if(itemName == "ForgeByBlood"){
                    other.gameObject.GetComponent<PlayerHealth>().ForgeByBlood();
                    audioManager.playSound("ForgeByBlood");

                }
                //Added item
                if(itemName == "BomberSpawner"){
                    other.gameObject.GetComponent<PlayerAttack>().BomberSpawner();
                    audioManager.playSound("BomberSpawner");
                    
                }

                Destroy(gameObject);
            }
         }
    }
}
