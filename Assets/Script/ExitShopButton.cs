using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class ExitShopButton : MonoBehaviour
{
    private GameObject gui;
    public Camera camaraTienda;
    public FirstPersonController fpsController;
    public GameObject FPC;

    void Start()
    {
        gui = GameObject.Find("GUI");
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }  

    void TaskOnClick()
    {
        AudioManager.instance.Play("ShopEnter");
        AudioManager.instance.Stop("Shop");
        AudioManager.instance.UnPause("Playing");
        //reanudar el juego
        Time.timeScale = 1;
            
        //"activar" el jugador
        fpsController.enabled = true;

        // Esperar 1 segundo para que el sonido del arma no se active antes de que el jugador pueda disparar
        Invoke("SonidoArma", 1f); 

        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor del ratón
        Cursor.visible = false; // Hacer invisible el cursor del ratón
        
        //cambiar GUIs
        Transform guiTransform = gui.transform;

        Transform PlayingGui = guiTransform.Find("GUI Playing");
        Transform ShopGui = guiTransform.Find("GUI Shop");

        ShopGui.gameObject.SetActive(false);
        PlayingGui.gameObject.SetActive(true);
    }

    void SonidoArma()
    {
        FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.GetComponent<AudioSource>().mute = false;
    }
}
