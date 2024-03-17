// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityStandardAssets.Characters.FirstPerson;

// public class UpgradeButton : MonoBehaviour
// {
//     private GameObject gui;
//     public Camera camaraTienda;
//     public FirstPersonController fpsController;
//     public GameObject FPC;

//     void Start()
//     {
//         gui = GameObject.Find("GUI");
//         Button button = GetComponent<Button>();
//         button.onClick.AddListener(TaskOnClick);
//     }  

//     void TaskOnClick()
//     {
//         //reanudar el juego
//         Time.timeScale = 1;
            
//         //"activar" el jugador
//         fpsController.enabled = true;

//         // Esperar 1 segundo para que el sonido del arma no se active antes de que el jugador pueda disparar
//         Invoke("SonidoArma", 1f); 

//         Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor del ratón
//         Cursor.visible = false; // Hacer invisible el cursor del ratón
        
//         //cambiar GUIs
//         Transform guiTransform = gui.transform;

//         Transform PlayingGui = guiTransform.Find("GUI Playing");
//         Transform UpgGui = guiTransform.Find("GUI Upgrades");

//         UpgGui.gameObject.SetActive(false);
//         PlayingGui.gameObject.SetActive(true);
//     }

//     void SonidoArma()
//     {
//         FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.GetComponent<AudioSource>().mute = false;
//     }
// }
