using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
