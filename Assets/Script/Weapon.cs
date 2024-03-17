using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    
    AudioSource audioSource;
    Animation animacion;

    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animacion = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        fireRate *= PlayerPrefs.GetFloat("FireRateM");
        
        if(Input.GetMouseButton(0)){
            if(Time.time >= nextFire){
                nextFire = Time.time + fireRate;
                audioSource.Play();
                animacion.wrapMode = WrapMode.Once;
                animacion.Play();
            }
        }

    }
}
