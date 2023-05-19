using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{

    public Transform magicSpawnPoint;
    public GameObject magicPrefab;
    public float magicSpeed=10;
    public float castCooldownInSeconds = 10f;
    public bool canCast = true;
    public bool canCastMagicCircle = true;
    public GameObject magicCircle;
    public GameObject magicCircleVisual;

    private int magicCircleCounter = 0;



 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.Q)){
                castAttackMagic();
            }


            if(Input.GetKeyDown(KeyCode.E)){
                if(canCastMagicCircle){
                    castMagicCircleCycle();
                }
            }

            


    }

    public void reduceCooldown(float cdReduction){
        castCooldownInSeconds-=cdReduction;
    }
    void castAttackMagic(){
        if(!canCast){
            return;
        }
        var magic  = Instantiate(magicPrefab,magicSpawnPoint.position,magicSpawnPoint.rotation);
        magic.GetComponent<Rigidbody>().velocity = magicSpawnPoint.forward * magicSpeed;
        StartCoroutine(StartCooldown());
       
    }


    public IEnumerator StartCooldown(){
        canCast = false;
        yield return new WaitForSeconds(castCooldownInSeconds);
        canCast = true;
    }


    private void castMagicCircleCycle(){
        canCastMagicCircle = false;
        castMagicCircle();
        Invoke("disableMagicCircle",1.0f);
        Invoke("castMagicCircle",2.0f);
        Invoke("disableMagicCircle",3.0f);
        Invoke("castMagicCircle",4.0f);
        Invoke("disableMagicCircle",5.0f);
        Invoke("castMagicCircle",6.0f);
        Invoke("disableMagicCircle",7.0f);
        Invoke("castMagicCircle",8.0f);
        Invoke("disableMagicCircle",9.0f);
        Invoke("enableCastingMagicCircle",30.0f);


    }
    private void castMagicCircle(){
        magicCircle.SetActive(true);
        if(magicCircleCounter==0){
            magicCircleVisual.SetActive(true);
        }
        magicCircleCounter++;
    }
    private void disableMagicCircle(){
        magicCircle.SetActive(false);
        magicCircleCounter++;

        if(magicCircleCounter == 10){
            magicCircleVisual.SetActive(false);
        }
    }
    private void enableCastingMagicCircle(){
        canCastMagicCircle = true;
    }
}
