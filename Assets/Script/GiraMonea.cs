using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraMonea : MonoBehaviour
{
    private float rotationSpeed;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerPrefs.SetInt("GoldM", 1);
        rotationSpeed = 50f;
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
            PlayerPrefs.SetInt("Oro", PlayerPrefs.GetInt("Oro") + 1*PlayerPrefs.GetInt("GoldM"));
            Invoke("DestruyeMonea", 1f);
        }
    }

    private void DestruyeMonea()
    {
        Destroy(gameObject);
    }
}
