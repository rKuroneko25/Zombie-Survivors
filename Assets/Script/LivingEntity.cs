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
    float vidaInicial;
    public float vidaActual; 

    public GameObject playerHealth;

    public UnityEvent EnemyExp;
    public GoldEvent  EnemyGold;

    public delegate void onDeathJugador();
    public static event onDeathJugador onDeathPlayer;

    protected virtual void Start()
    {
        muerto = false;
        if(gameObject.name == "Player"){
            vidaInicial = 100;
            playerHealth.GetComponent<Image>().fillAmount = 1;
        }
        else{
            vidaInicial = PlayerPrefs.GetFloat("VidaEnemigos");
            transform.GetChild(0).GetComponent<TextMeshPro>().text = "HP: " + Mathf.RoundToInt(vidaInicial).ToString();
        }
        vidaActual = vidaInicial;
    }

    public void TakeDamage(float damage){
        if(gameObject.name == "Player"){
            playerHealth.GetComponent<Image>().fillAmount = (vidaActual-damage*PlayerPrefs.GetFloat("Armor"))/vidaInicial;       
            FindObjectOfType<AudioManager>().Play("Damage"); 
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

    public void ChangeMaxHealth(float health){
        vidaInicial *= health;
        playerHealth.GetComponent<Image>().fillAmount = vidaActual/vidaInicial;
    }

    public void ChangeHealth(float health){
        if(health+vidaActual > vidaInicial){
            vidaActual = vidaInicial;
        }
        else{
            vidaActual += health;
        }
        playerHealth.GetComponent<Image>().fillAmount = vidaActual/vidaInicial;
    }
}