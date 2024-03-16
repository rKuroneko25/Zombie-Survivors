using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private GameObject gui;
    public GameObject FPC;
    AudioSource audioSource;
    public Text oro;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Oro",6000); ////////////////////////////BORRAR
        oro.text = "GOLD: " + PlayerPrefs.GetInt("Oro").ToString();
        gui = GameObject.Find("GUI");
        audioSource = GetComponent<AudioSource>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        switch (PlayerPrefs.GetString("ArmaSeleccionada"))
        {
            case "UZI":
                ComprarArma(100);
                break;
            case "M4":
                ComprarArma(200);
                break;
            case "AK":
                ComprarArma(300);
                break;
            case "SHOTGUN":
                ComprarArma(400);
                break;
            case "GATLING":
                ComprarArma(500);
                break;
            case "RPG":
                ComprarArma(1000);
                break;
            default:
                break;
        }
    }

    void ComprarArma(int precio)
    {
        if (PlayerPrefs.GetInt("Oro") >= precio)
        {
            PlayerPrefs.SetInt("Oro", PlayerPrefs.GetInt("Oro") - precio);
            oro.text = "GOLD: " + PlayerPrefs.GetInt("Oro").ToString();
            Transform guiTransform = gui.transform;
            Transform ShopGui = guiTransform.Find("GUI Shop");
            Transform Arma = ShopGui.Find(PlayerPrefs.GetString("ArmaSeleccionada"));
            Destroy(Arma.gameObject);

            FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.SetActive(false);
            PlayerPrefs.SetString("ArmaActual", PlayerPrefs.GetString("ArmaSeleccionada"));
            FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.SetActive(true);
            audioSource.Play();
        }
    }
}
