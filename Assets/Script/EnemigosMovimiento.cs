using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : LivingEntity
{

    UnityEngine.AI.NavMeshAgent agent;
    Transform target;

    public float damage;  

    float tiempoEntreAtaques = 0.5f;
    float nextAttackTime;

    bool atacando;

    float myCollisionRadius;
    float targetCollisionRadius;

    LivingEntity targetEntity;

    bool bFinalJuego = false;

    float sqrDsttoTarget;


    protected override void Start()
    {
        base.Start();
        JugadorControler.onDeathPlayer += FinalizarJuego;

        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 

        targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius; 
        myCollisionRadius = GetComponent<CapsuleCollider>().radius;

    }


    void FinalizarJuego()
    {
        bFinalJuego = true;
    }


    void Update()
    {

        sqrDsttoTarget = (target.position - transform.position).sqrMagnitude;

        if(!bFinalJuego){
            if(!atacando){
                
                Vector3 DirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - DirToTarget * (myCollisionRadius + targetCollisionRadius);
                agent.SetDestination(targetPosition);

                if(Time.time > nextAttackTime)
                {
                    if(sqrDsttoTarget <= 30f)
                    {
                        atacando = true;

                        Debug.Log("Atacando");
                        FindObjectOfType<AudioManager>().Play("EnemyAttack");
                        transform.GetChild(1).GetComponent<Animator>().SetTrigger("Attack");

                        nextAttackTime = Time.time + tiempoEntreAtaques;
                        Invoke("Atacar", 1f);
                    }            
                }
            }
        }
    }

    void Atacar()
    {
        
        if(sqrDsttoTarget <= 20f){
            agent.enabled = false;
            
            targetEntity = target.GetComponent<LivingEntity>();
            targetEntity.TakeDamage(damage);

            agent.enabled = true;
        }  
        atacando = false;
        transform.GetChild(1).GetComponent<Animator>().SetTrigger("Walk");
    }


    void OnDestroy()
    {
        JugadorControler.onDeathPlayer -= FinalizarJuego;
    }

}
