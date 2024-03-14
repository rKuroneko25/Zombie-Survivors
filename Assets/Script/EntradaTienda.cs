using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntradaTienda : MonoBehaviour
{
    private GameObject gui;

    void Start()
    {
        gui = GameObject.Find("GUI");
    }  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pausar el juego
            
            //desactivar el movimiento del jugador
            other.gameObject.SetActive(false);

            //cambiar GUIs
            Transform guiTransform = gui.transform;

            Transform PlayingGui = guiTransform.Find("GUI Playing");
            Transform ShopGui = guiTransform.Find("GUI Shop");

            PlayingGui.gameObject.SetActive(false);
            ShopGui.gameObject.SetActive(true);
        }
    }
}
