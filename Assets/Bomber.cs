using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomber : MonoBehaviour
{
    GameObject enemy;
    UnityEngine.AI.NavMeshAgent nav; 
    EnemySpawnAndKillCount esakc;

    public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BomberExplode",5.0f);
        esakc = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemySpawnAndKillCount>();
        nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(esakc.enemySpawnCount!=esakc.enemyKillCount){
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            nav.SetDestination(enemy.GetComponent<Transform>().position);
        }
    }



    private void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
            BomberExplode();
            other.GetComponent<Enemy>().Damage(10);
        }
    }


    private void BomberExplode(){
        FindObjectOfType<AudioManager>().playSound("ExplosionTrap");
        Explosion.SetActive(true);
        Invoke("DestroyBomber",0.35f);
    }

    private void DestroyBomber(){
        Destroy(gameObject);
    }
}
