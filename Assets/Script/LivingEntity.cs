using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;


public class LivingEntity : MonoBehaviour, IDamageable
{
    bool muerto = false;
    float vidaInicial;
    public float vidaActual; 

    public GameObject playerHealth;

    public delegate void onDeathJugador();
    public static event onDeathJugador onDeathPlayer;

    public UnityEvent EnemyExp;

    protected virtual void Start()
    {
        muerto = false;
        if(gameObject.name == "Player"){
            vidaInicial = 100;
            playerHealth.GetComponent<TextMeshProUGUI>().text = "HP: "+vidaActual.ToString()+" / "+vidaInicial.ToString();
        }
        else{
            vidaInicial = PlayerPrefs.GetFloat("VidaEnemigos");
            transform.GetChild(0).GetComponent<TextMeshPro>().text = "HP: " + Mathf.RoundToInt(vidaInicial).ToString();
        }
        vidaActual = vidaInicial;
    }

    public void TakeDamage(float damage){
        if(gameObject.name == "Player"){
            playerHealth.GetComponent<TextMeshProUGUI>().text = "HP: "+(vidaActual-damage*PlayerPrefs.GetFloat("Armor")).ToString()+" / "+vidaInicial.ToString();
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
        }
        else{
            EnemyExp.Invoke();
        }
        Destroy(gameObject);
    }

    public void ChangeMaxHealth(float health){
        vidaInicial *= health;
        playerHealth.GetComponent<TextMeshProUGUI>().text = "HP: "+vidaActual.ToString()+" / "+vidaInicial.ToString();
    }

    public void ChangeHealth(float health){
        if(health+vidaActual > vidaInicial){
            vidaActual = vidaInicial;
        }
        else{
            vidaActual += health;
        }

        playerHealth.GetComponent<TextMeshProUGUI>().text = "HP: "+vidaActual.ToString()+" / "+vidaInicial.ToString();
    }
}