using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Upgrades : MonoBehaviour
{
    float SpeedM;
    float HeathM;
    float Level;

    public TextMeshProUGUI LevelText;

    public GameObject GUIPlaying;
    public GameObject GUIUpgrade;
    public GUIUpgrades UpgradeTime;

    // Start is called before the first frame update
    void Start()
    {
        Level = 0;
        SpeedM = 1;
        HeathM = 1;
        PlayerPrefs.SetInt("Exp", 0);
        PlayerPrefs.SetInt("Oro", 0);
        PlayerPrefs.SetFloat("DamageM", 1);
        PlayerPrefs.SetFloat("FireRateM", 1);
        PlayerPrefs.SetInt("GoldM", 1);
        PlayerPrefs.SetInt("ExpM", 1);
        PlayerPrefs.SetFloat("Armor", 1);
    }

    public GameObject player;

    void Update(){
        if(PlayerPrefs.GetInt("Exp") >= 10*(Level+1)){
            Level++;
            PlayerPrefs.SetInt("Exp", 0);

            LevelText.text = Level.ToString();
            FindObjectOfType<AudioManager>().Play("LevelUp");
            GUIPlaying.transform.GetChild(1).GetComponent<Image>().fillAmount = 0;
    
            Time.timeScale = 0;
            player.GetComponent<FirstPersonController>().enabled = false;

            player.transform.GetChild(0).transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.GetComponent<AudioSource>().mute = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GUIPlaying.SetActive(false);
            GUIUpgrade.SetActive(true);

            UpgradeTime.LevelUp();
        }
    }

    public void Speed()
    {
        SpeedM *= 1.1f;
        player.GetComponent<FirstPersonController>().ChangeSpeed(SpeedM);
    }

    public void MaxHealth()
    {
        HeathM *= 1.1f;
        player.GetComponent<LivingEntity>().ChangeMaxHealth(HeathM);
    }

    public void Heal(){
        player.GetComponent<LivingEntity>().ChangeHealth(10*PlayerPrefs.GetInt("Ronda"));
    }

    public void Damage()
    {
        PlayerPrefs.SetFloat("DamageM", PlayerPrefs.GetFloat("DamageM")*1.5f);
    }

    public void FireRate()
    {
        PlayerPrefs.SetFloat("FireRateM", PlayerPrefs.GetFloat("FireRateM")*0.9f);
    }

    public void InstaKill()
    {
        PlayerPrefs.SetFloat("DamageM", PlayerPrefs.GetFloat("DamageM")*10000);
        Invoke("NoInstaKill", 20.0f); 
    }
    void NoInstaKill()
    {
        PlayerPrefs.SetFloat("DamageM", PlayerPrefs.GetFloat("DamageM")/10000);
    }

    public void Gold()
    {
        PlayerPrefs.SetInt("GoldM", PlayerPrefs.GetInt("GoldM")*2);
    }

    public void Exp()
    {
        PlayerPrefs.SetInt("ExpM", PlayerPrefs.GetInt("ExpM")*2);
    }

    public void Armor()
    {
        PlayerPrefs.SetFloat("Armor", PlayerPrefs.GetFloat("Armor")*0.75f);
    }
}
