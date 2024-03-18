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
        oro.text = "GOLD: " + PlayerPrefs.GetInt("Oro").ToString();
        gui = GameObject.Find("GUI");
        audioSource = GetComponent<AudioSource>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Transform guiTransform = gui.transform;
        Transform ShopGui = guiTransform.Find("GUI Shop");
        Transform Arma = ShopGui.Find(PlayerPrefs.GetString("ArmaSeleccionada"));
        Transform Arma_pr = Arma.Find("Pr");
        bool comprada = false;
        if (Arma_pr.GetComponent<Text>().text == "FREE!")
        {
            comprada = true;
        }
        switch (PlayerPrefs.GetString("ArmaSeleccionada"))
        {
            case "UZI":
                ComprarArma(10,comprada);
                break;
            case "M4":
                ComprarArma(75,comprada);
                break;
            case "AK":
                ComprarArma(200,comprada);
                break;
            case "SHOTGUN":
                ComprarArma(1000,comprada);
                break;
            case "GATLING":
                ComprarArma(5000,comprada);
                break;
            case "RPG":
                ComprarArma(9999,comprada);
                break;
            default:
                break;
        }
    }

    void ComprarArma(int precio, bool comprada)
    {
        if (PlayerPrefs.GetInt("Oro") >= precio || comprada)
        {
            if (!comprada)
                PlayerPrefs.SetInt("Oro", PlayerPrefs.GetInt("Oro") - precio);
            oro.text = "GOLD: " + PlayerPrefs.GetInt("Oro").ToString();
            Transform guiTransform = gui.transform;
            Transform ShopGui = guiTransform.Find("GUI Shop");
            Transform Arma = ShopGui.Find(PlayerPrefs.GetString("ArmaSeleccionada"));
            Transform Arma_pr = Arma.Find("Pr");
            Arma_pr.GetComponent<Text>().text = "FREE!";

            FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.SetActive(false);
            PlayerPrefs.SetString("ArmaActual", PlayerPrefs.GetString("ArmaSeleccionada"));
            PlayerPrefs.SetString("ArmaSeleccionada", "NINGUNA");
            FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.SetActive(true);
            FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.GetComponent<AudioSource>().mute = true;
            audioSource.Play();
        }
    }
}
