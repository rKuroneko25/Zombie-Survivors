using UnityEngine;
using UnityEngine.EventSystems;

public class RestablecerHover : MonoBehaviour, IPointerClickHandler
{
    public CambiarImagen[] armas;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Restablecer el hover en todas las armas
        foreach (CambiarImagen arma in armas)
        {
            arma.ResetHover();
        }
        PlayerPrefs.SetString("ArmaSeleccionada", "NINGUNA");
    }
}