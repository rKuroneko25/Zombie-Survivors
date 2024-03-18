using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiraMonea : MonoBehaviour
{
    private float rotationSpeed;
    private AudioSource audioSource;

    bool cogiendo;

    void Start()
    {
        cogiendo = false;
        cogiendo = false;
        audioSource = GetComponent<AudioSource>();
        rotationSpeed = 50f;
        Invoke("DestruyeMonea", 30f);
    }


    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!cogiendo){
            if (other.CompareTag("Player"))
            {
                cogiendo = true;
                audioSource.Play();
                PlayerPrefs.SetInt("Oro", PlayerPrefs.GetInt("Oro")+1*PlayerPrefs.GetInt("GoldM"));
                Invoke("DestruyeMonea", 1f);
            }
        }
    }

    private void DestruyeMonea()
    {
        Destroy(gameObject);
    }
}
