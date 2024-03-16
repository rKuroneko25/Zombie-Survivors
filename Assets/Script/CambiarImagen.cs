using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CambiarImagen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite imagenNormal;
    public Sprite imagenHover;

    private Image imagen;
    private static CambiarImagen armaConHover; // Variable estática para mantener la referencia a la última arma con hover

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        imagen = GetComponent<Image>();
        imagen.sprite = imagenNormal;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (armaConHover != this) // Solo cambia si esta arma no es la que ya tiene el hover
            imagen.sprite = imagenHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (armaConHover != this) // Solo cambia si esta arma no es la que ya tiene el hover
            imagen.sprite = imagenNormal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Si hay otra arma con hover, restablece su estado
        if (armaConHover != null && armaConHover != this)
            armaConHover.ResetHover();

        armaConHover = this; // Actualiza la referencia a esta arma
        imagen.sprite = imagenHover; // Establece el hover en esta arma
        audioSource.Play();
        PlayerPrefs.SetString("ArmaSeleccionada", gameObject.name);
    }

    // Método para restablecer el estado de "hover"
    public void ResetHover()
    {
        imagen.sprite = imagenNormal;
    }
}