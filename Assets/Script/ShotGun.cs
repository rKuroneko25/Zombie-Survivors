using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    
    AudioSource audioSource;
    Animation animacion;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animacion = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            animacion.wrapMode = WrapMode.Once;
            animacion.Play();
        }

    }
}
