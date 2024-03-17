using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class JugadorControler : LivingEntity
{
    DisparaBala controladorBala;

    Rigidbody rb;
    UnityEngine.Vector3 moveInput, moveVelocity;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        controladorBala = GetComponent<DisparaBala>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {                
            controladorBala.Dispara();
        }
        if(Input.GetMouseButton(1))
        {
            controladorBala.Dispara();
        }
    }

   

}
