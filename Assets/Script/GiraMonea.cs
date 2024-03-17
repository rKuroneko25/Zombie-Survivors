using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiraMonea : MonoBehaviour
{
    private float rotationSpeed;
    private AudioSource audioSource;

    void Start()
    {
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
            audioSource.Play();
            PlayerPrefs.SetInt("Oro", PlayerPrefs.GetInt("Oro")*PlayerPrefs.GetInt("GoldM"));
            Invoke("DestruyeMonea", 1f);
        }
    }

    private void DestruyeMonea()
    {
        Destroy(gameObject);
    }
}
