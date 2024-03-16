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
        //reanudar el juego
        Time.timeScale = 1;
            
        //"activar" el jugador
        fpsController.enabled = true;

        //activar sonido del arma
        FPC.transform.Find(PlayerPrefs.GetString("ArmaActual")).gameObject.GetComponent<AudioSource>().mute = false;

        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor del ratón
        Cursor.visible = false; // Hacer invisible el cursor del ratón
        
        //cambiar GUIs
        Transform guiTransform = gui.transform;

        Transform PlayingGui = guiTransform.Find("GUI Playing");
        Transform ShopGui = guiTransform.Find("GUI Shop");

        ShopGui.gameObject.SetActive(false);
        PlayingGui.gameObject.SetActive(true);
    }
}
