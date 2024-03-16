using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EntradaTienda : MonoBehaviour
{
    private GameObject gui;
    public Camera camaraTienda;
    public FirstPersonController fpsController;
    public GameObject FPC;

    void Start()
    {
        PlayerPrefs.SetString("ArmaActual", "SHOTGUN"); ////////////////////////////BORRAR
        gui = GameObject.Find("GUI");
        camaraTienda.gameObject.SetActive(false);
    }  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioManager.instance.Pause("Playing");
            //AudioManager.instance.Play("Shop");

            //pausar el juego
            Time.timeScale = 0;
            
            //"desactivar" el jugador
            fpsController.enabled = false;

            //desactivar sonido del arma
            FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.GetComponent<AudioSource>().mute = true;

            Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor del ratón
            Cursor.visible = true; // Hacer visible el cursor del ratón
            

            //cambiar GUIs
            Transform guiTransform = gui.transform;

            Transform PlayingGui = guiTransform.Find("GUI Playing");
            Transform ShopGui = guiTransform.Find("GUI Shop");

            PlayingGui.gameObject.SetActive(false);
            ShopGui.gameObject.SetActive(true);
        }
    }
}
