using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiraMonea : MonoBehaviour
{
    private float rotationSpeed;
    private AudioSource audioSource;

    private bool cogiendo;

    void Start()
    {
        cogiendo = false;
        audioSource = GetComponent<AudioSource>();
        rotationSpeed = 50f;
        Invoke("DestruyeMonea", 10f);
    }


    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!cogiendo) {
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
