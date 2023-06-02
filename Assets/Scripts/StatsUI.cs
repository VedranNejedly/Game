using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public GameObject player;
    private PlayerMagic playerMagic;
    public MagicCircle magicCircle;
    private PlayerAttack playerAttack;
    private  PlayerHealth PlayerHealth;
    public GameObject[] statsArray = new GameObject[8];
    private TMP_Text temp;
    public GameObject statsUI;
    private EnemySpawnAndKillCount esakc;
    float tempFloatValue;
    int tempIntValue;
    private bool statsUIisActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = player.GetComponent<PlayerAttack>();  
        PlayerHealth = player.GetComponent<PlayerHealth>();  
        playerMagic = player.GetComponent<PlayerMagic>();   
        esakc = player.GetComponent<EnemySpawnAndKillCount>();   
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.I)){
                if(!statsUIisActive){
                    UpdateUIValues();
                    statsUI.SetActive(true);
                    statsUIisActive=true;
                }else{
                    statsUI.SetActive(false);
                    statsUIisActive=false;
                }
        }
    }

    private void UpdateUIValues(){
        tempIntValue = playerAttack.meeleDamage;
        statsArray[0].GetComponent<TMP_Text>().text = tempIntValue.ToString();
        tempFloatValue = 1.0f /playerAttack.timeToAttack;
        statsArray[1].GetComponent<TMP_Text>().text = tempFloatValue.ToString();
        tempIntValue = playerAttack.magicDamage;
        statsArray[2].GetComponent<TMP_Text>().text = tempIntValue.ToString();
        tempFloatValue = playerMagic.castCooldownInSeconds;
        statsArray[3].GetComponent<TMP_Text>().text = tempFloatValue.ToString();
        tempIntValue = magicCircle.magicCircleDamage;
        statsArray[4].GetComponent<TMP_Text>().text = tempIntValue.ToString();
        tempFloatValue = playerMagic.magicCircleCooldown;
        statsArray[5].GetComponent<TMP_Text>().text = tempFloatValue.ToString();

        tempIntValue = PlayerHealth.playerArmor;
        statsArray[6].GetComponent<TMP_Text>().text = tempIntValue.ToString();

        tempIntValue = esakc.enemyKillCount;
        statsArray[7].GetComponent<TMP_Text>().text = tempIntValue.ToString();

    }
}
