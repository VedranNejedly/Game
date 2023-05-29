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
    public float magicCircleCooldown = 30.0f;
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
        FindObjectOfType<AudioManager>().playSound("MagicAttack");  
        var magic  = Instantiate(magicPrefab,magicSpawnPoint.position,magicSpawnPoint.rotation);
        magic.transform.Rotate(0,-90,0,Space.Self);

        magic.GetComponent<Rigidbody>().velocity = magicSpawnPoint.forward * magicSpeed;
        StartCoroutine(DestroyAfterSeconds(4.0f,magic));
        canCast = false;
        Invoke("StartCooldown",castCooldownInSeconds);
       
    }


    public void StartCooldown(){
        canCast = true;
    }


    private void castMagicCircleCycle(){
        canCastMagicCircle = false;
        FindObjectOfType<AudioManager>().playSound("FieldMagic");  
        castMagicCircle();
        Invoke("disableMagicCircle",1.0f);
        Invoke("castMagicCircle",1.01f);
        Invoke("disableMagicCircle",2.0f);
        Invoke("castMagicCircle",2.01f);
        Invoke("disableMagicCircle",3.0f);
        Invoke("castMagicCircle",3.01f);
        Invoke("disableMagicCircle",4.0f);
        Invoke("castMagicCircle",4.01f);
        Invoke("disableMagicCircle",5.0f);
        Invoke("enableCastingMagicCircle",magicCircleCooldown);


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
            magicCircleCounter = 0;
            FindObjectOfType<AudioManager>().stopSound("FieldMagic");
        }
    }
    private void enableCastingMagicCircle(){
        canCastMagicCircle = true;
    }



    public IEnumerator DestroyAfterSeconds(float time,GameObject magic){
        yield return new WaitForSeconds(time);
        FindObjectOfType<AudioManager>().stopSound("MagicAttack");  
        Destroy(magic);

    }
}
