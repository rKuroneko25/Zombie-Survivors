using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContadorOroPlaying : MonoBehaviour
{
    public TextMeshProUGUI textoOro;

    void Start()
    {
        textoOro.text = PlayerPrefs.GetInt("Oro").ToString() + "Gold";
    }

    void Update()
    {
        textoOro.text = PlayerPrefs.GetInt("Oro").ToString() + "Gold";
    }
}