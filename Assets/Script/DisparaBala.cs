using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisparaBala : MonoBehaviour
{
    public GameObject balaPrefab;
    public GameObject Rocket;
    Transform puntoDisparo;
    GameObject GUN;
    
    float fireRate;
    float nextFire = 0.0f;

    void Start()
    {
        puntoDisparo = GameObject.FindGameObjectWithTag("PuntoDisparo").transform;

        PlayerPrefs.SetString("ArmaActual", "HANDGUN");
    }   

    // Update is called once per frame
    public void Dispara()
    {
        if(Time.time >= nextFire)
        {
            switch(PlayerPrefs.GetString("ArmaActual")){
                case "HANDGUN":
                    fireRate = 0.3f;
                    break;
                case "UZI":
                    fireRate = 0.7f;
                    break;
                case "M4":
                    fireRate = 0.17f;
                    break;
                case "AK":
                    fireRate = 0.12f;
                    break;
                case "SHOTGUN":
                    fireRate = 0.7f;
                    break;
                case "GATLING":
                    fireRate = 0.05f;
                    break;
                case "RPG":
                    fireRate = 1.0f;
                    break;
            }
            fireRate *= PlayerPrefs.GetFloat("FireRateM");

            nextFire = Time.time + fireRate;

            if(PlayerPrefs.GetString("ArmaActual") == "HANDGUN" || PlayerPrefs.GetString("ArmaActual") == "M4" || PlayerPrefs.GetString("ArmaActual") == "AK" || PlayerPrefs.GetString("ArmaActual") == "UZI"){
                Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            }
            
            if(PlayerPrefs.GetString("ArmaActual") == "GATLING"){
                Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * Quaternion.Euler(Random.Range(-2, 2), Random.Range(-2, 2), 0));
            }

            if(PlayerPrefs.GetString("ArmaActual") == "UZI"){
                Invoke("a", 0.1f);
                Invoke("a", 0.2f);
                Invoke("a", 0.3f);
                Invoke("a", 0.4f);
            }
        
            if(PlayerPrefs.GetString("ArmaActual") == "SHOTGUN"){
                Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * Quaternion.Euler(Random.Range(-4, 4), Random.Range(-4, 4), 0));
                Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * Quaternion.Euler(Random.Range(-4, 4), Random.Range(-4, 4), 0));
                Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * Quaternion.Euler(Random.Range(-4, 4), Random.Range(-4, 4), 0));
                Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * Quaternion.Euler(Random.Range(-4, 4), Random.Range(-4, 4), 0));
                Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * Quaternion.Euler(Random.Range(-4, 4), Random.Range(-4, 4), 0));
            }

            if(PlayerPrefs.GetString("ArmaActual") == "RPG"){
                Instantiate(Rocket, puntoDisparo.position, puntoDisparo.rotation);
            }

            GUN = GameObject.Find(PlayerPrefs.GetString("ArmaActual"));

            GUN.transform.GetChild(0).gameObject.SetActive(true);
            

            if(PlayerPrefs.GetString("ArmaActual") == "UZI"){
                Invoke("Disparo1", 0.5f);
            }
            else{
                Invoke("Disparo1", 0.1f);
            }
        }
    }

    void a(){
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }

    void Disparo1()
    {
        GUN.transform.GetChild(0).gameObject.SetActive(false);
    }


}
