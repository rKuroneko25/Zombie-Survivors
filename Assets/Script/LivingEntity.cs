using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

[System.Serializable]
public class GoldEvent : UnityEvent<Vector3> { }

public class LivingEntity : MonoBehaviour, IDamageable
{
    bool muerto = false;
    public float vidaInicial;
    public float vidaActual; 

    public GameObject playerHealth;

    public UnityEvent EnemyExp;
    public GoldEvent  EnemyGold;

    public delegate void onDeathJugador();
    public static event onDeathJugador onDeathPlayer;

    protected virtual void Start()
    {
        muerto = false;
        vidaActual = vidaInicial;
    }

    public void TakeDamage(float damage){
        if(gameObject.name == "Player"){
            playerHealth.GetComponent<TextMeshProUGUI>().text = "HP: "+(vidaActual-damage).ToString();
        }
        else{
            transform.GetChild(0).GetComponent<TextMeshPro>().text = "HP: "+(vidaActual-damage).ToString();
        }
        vidaActual -= damage;
        if(vidaActual <= 0 && !muerto){
            Morir();
        }
    }

    public virtual void Morir()
    {
        muerto = true;
        Debug.Log("Muerto");
        if(gameObject.name == "Player"){
            if(onDeathPlayer != null)
            {
                onDeathPlayer();
            }
        } else {
            EnemyExp.Invoke();
            EnemyGold.Invoke(transform.position);
        }
        Destroy(gameObject);
    }
}