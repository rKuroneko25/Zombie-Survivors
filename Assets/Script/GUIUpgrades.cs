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

    public Dictionary<string, Sprite> diccionarioSprites = new Dictionary<string, Sprite>();

    public List<string> mejorasDisponibles = new List<string>{"SpeedUp", "HealthUp", "DamageUp", "FireRateUp", "Instakill", "MoreExp", "MoreGold", "ArmorUp", "Heal"};

    void Start()
    {
        LlenarDiccionarioSprites();

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
        diccionarioSprites.Add("SpeedUp", Resources.Load<Sprite>("SpeedUpSprite"));
        diccionarioSprites.Add("HealthUp", Resources.Load<Sprite>("HealthUpSprite"));
        diccionarioSprites.Add("DamageUp", Resources.Load<Sprite>("DamageUpSprite"));
        diccionarioSprites.Add("FireRateUp", Resources.Load<Sprite>("FireRateUpSprite"));
        diccionarioSprites.Add("Instakill", Resources.Load<Sprite>("InstakillSprite"));
        diccionarioSprites.Add("MoreExp", Resources.Load<Sprite>("MoreExpSprite"));
        diccionarioSprites.Add("MoreGold", Resources.Load<Sprite>("MoreGoldSprite"));
        diccionarioSprites.Add("ArmorUp", Resources.Load<Sprite>("ArmorUpSprite"));
        diccionarioSprites.Add("Heal", Resources.Load<Sprite>("HealSprite"));
    }
}
