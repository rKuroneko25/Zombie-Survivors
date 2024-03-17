using UnityEngine;
using UnityEngine.UI;

public class SeleccionadorDeImagen : MonoBehaviour
{
    public Image[] imagenes;
    private Image imagenSeleccionada;
    public Button BTUpgrade;

    void Start()
    {
        foreach (Image imagen in imagenes)
        {
            imagen.GetComponent<Button>().onClick.AddListener(() => SeleccionarImagen(imagen));
        }
    }

    void SeleccionarImagen(Image imagen)
    {
        BTUpgrade.gameObject.SetActive(true);

        if (imagenSeleccionada != null)
        {
            imagenSeleccionada.color = Color.white; // Cambiar el color a blanco (no seleccionado)
        }

        // Marcar la nueva imagen como seleccionada
        imagenSeleccionada = imagen;
        imagenSeleccionada.color = Color.green; // Cambiar el color a verde (seleccionado) o aplica un efecto visual para indicar la selección

        //Debug.Log("Imagen seleccionada: " + imagenSeleccionada.name);
        Debug.Log("Texto de la imagen seleccionada: " + imagenSeleccionada.GetComponentInChildren<Text>().text);
        PlayerPrefs.SetString("MejoraSeleccionada", imagenSeleccionada.GetComponentInChildren<Text>().text);
    }
}