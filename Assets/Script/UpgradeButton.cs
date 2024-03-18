using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UpgradeButton : MonoBehaviour
{
    public GameObject GUIPlaying;
    public GameObject GUIUpgrade;
    public GameObject player;
    public Upgrades upgrades;
    public Button BTUpgrade;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }  

    void TaskOnClick()
    {
        AudioManager.instance.Play("NewUpgrade");
        Debug.Log("Mejora seleccionada: " + PlayerPrefs.GetString("MejoraSeleccionada"));
        switch (PlayerPrefs.GetString("MejoraSeleccionada"))
        {
            case "SpeedUp":
                upgrades.Speed();
                break;
            case "HealthUp":
                upgrades.MaxHealth();
                break;
            case "DamageUp":
                upgrades.Damage();
                break;
            case "FireRateUp":
                upgrades.FireRate();
                break;
            case "Instakill":
                upgrades.InstaKill();
                break;
            case "MoreGold":
                upgrades.Gold();
                break;
            case "MoreExp":
                upgrades.Exp();
                break;
            case "ArmorUp":
                upgrades.Armor();
                break;
            case "Heal":
                upgrades.Heal();
                break;
            default:
                break;
        }
        BTUpgrade.gameObject.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<FirstPersonController>().enabled = true;

        // Esperar 1 segundo para que el sonido del arma no se active antes de que el jugador pueda disparar
        Invoke("SonidoArma", 1f); 

        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor del ratón
        Cursor.visible = false; // Hacer invisible el cursor del ratón

        GUIPlaying.SetActive(true);
        GUIUpgrade.SetActive(false);
        PlayerPrefs.SetString("DesactivaMarcado", "True");
    }

    void SonidoArma()
    {
        player.transform.GetChild(0).transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.GetComponent<AudioSource>().mute = false;
    }
}
