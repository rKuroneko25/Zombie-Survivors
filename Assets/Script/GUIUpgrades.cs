using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIUpgrades : MonoBehaviour
{
    public Image leftImage;
    public Text leftText;
    public Image middleImage;
    public Text middleText;
    public Image rightImage;
    public Text rightText;
    public Button BTUpgrade;
    private bool lleno;

    public Dictionary<string, Sprite> diccionarioSprites = new Dictionary<string, Sprite>();

    public List<string> mejorasDisponibles = new List<string>{"SpeedUp", "HealthUp", "DamageUp", "FireRateUp", "Instakill", "MoreExp", "MoreGold", "ArmorUp", "Heal"};

    public List<Sprite> sprites;
    public List<string> upgrades;

    void Start()
    {
        lleno = false;
        // BTUpgrade.gameObject.SetActive(false);

        //LlenarDiccionarioSprites();

        // List<string> mejoras = ObtenerMejorasAleatorias();

        // leftText.text = mejoras[0];
        // leftImage.sprite = ObtenerSpriteDeMejora(mejoras[0]);

        // middleText.text = mejoras[1];
        // middleImage.sprite = ObtenerSpriteDeMejora(mejoras[1]);

        // rightText.text = mejoras[2];
        // rightImage.sprite = ObtenerSpriteDeMejora(mejoras[2]);
    }

    public void LevelUp(){
        LlenarDiccionarioSprites();
        BTUpgrade.gameObject.SetActive(false);
        
        List<string> mejoras = ObtenerMejorasAleatorias();

        leftText.text = mejoras[0];
        leftImage.sprite = ObtenerSpriteDeMejora(mejoras[0]);

        middleText.text = mejoras[1];
        middleImage.sprite = ObtenerSpriteDeMejora(mejoras[1]);

        rightText.text = mejoras[2];
        rightImage.sprite = ObtenerSpriteDeMejora(mejoras[2]);
    }

    public List<string> ObtenerMejorasAleatorias()
    {
        List<string> mejorasSeleccionadas = new List<string>();
        
        List<string> mejorasDisponiblesCopia = new List<string>(mejorasDisponibles);

        if (PlayerPrefs.GetInt("SpeedM") == 6)
        {
            mejorasDisponiblesCopia.Remove("SpeedUp");
        }

        if (PlayerPrefs.GetInt("FireRateCap") == 6)
        {
            mejorasDisponiblesCopia.Remove("FireRateUp");
        }

        if (PlayerPrefs.GetInt("GoldMCap") == 4)
        {
            mejorasDisponiblesCopia.Remove("MoreGold");
        }

        if (PlayerPrefs.GetInt("ExpMCap") == 4)
        {
            mejorasDisponiblesCopia.Remove("MoreExp");
        }

        if (PlayerPrefs.GetInt("ArmorCap") == 11)
        {
            mejorasDisponiblesCopia.Remove("ArmorUp");
        }

        for (int i = 0; i < 3; i++)
        {
            int indiceAleatorio = Random.Range(0, mejorasDisponiblesCopia.Count);
            mejorasSeleccionadas.Add(mejorasDisponiblesCopia[indiceAleatorio]);
            mejorasDisponiblesCopia.RemoveAt(indiceAleatorio);
        }

        return mejorasSeleccionadas;
    }

    Sprite ObtenerSpriteDeMejora(string nombreMejora)
    {
        return diccionarioSprites[nombreMejora];
    }

    void LlenarDiccionarioSprites()
    {
        if (!lleno){
            lleno = true;
            diccionarioSprites.Add("SpeedUp", Resources.Load<Sprite>("SpeedUp"));
            diccionarioSprites.Add("HealthUp", Resources.Load<Sprite>("HealthUp"));
            diccionarioSprites.Add("DamageUp", Resources.Load<Sprite>("DamageUp"));
            diccionarioSprites.Add("FireRateUp", Resources.Load<Sprite>("FireRateUp"));
            diccionarioSprites.Add("Instakill", Resources.Load<Sprite>("Instakill"));
            diccionarioSprites.Add("MoreExp", Resources.Load<Sprite>("MoreExp"));
            diccionarioSprites.Add("MoreGold", Resources.Load<Sprite>("MoreGold"));
            diccionarioSprites.Add("ArmorUp", Resources.Load<Sprite>("ArmorUp"));
            diccionarioSprites.Add("Heal", Resources.Load<Sprite>("Heal"));
        }

    }
}
