using UnityEngine;
using UnityEngine.UI;

public class ContadorOro : MonoBehaviour
{
    public Text textoOro;

    void Start()
    {
        textoOro.text = "GOLD: " + PlayerPrefs.GetInt("Oro").ToString();
    }

    void Update()
    {
        textoOro.text = "GOLD: " + PlayerPrefs.GetInt("Oro").ToString();
    }
}