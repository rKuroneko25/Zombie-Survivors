using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject Enemigo;
    public Vector3[] posiciones;
    float tiempoEntreEnemigosActual;
    float TEE;
    public GameObject orito;
    int enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = 1;
        tiempoEntreEnemigosActual = 5;
        TEE = 5;
        PlayerPrefs.SetFloat("VidaEnemigos", 10);
        PlayerPrefs.SetInt("Ronda",1);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoEntreEnemigosActual -= Time.deltaTime; 
        
        if (tiempoEntreEnemigosActual <= 0)
        {
            if(enemies%10 == 0){
                TEE*=0.9f;
                PlayerPrefs.SetFloat("VidaEnemigos", PlayerPrefs.GetFloat("VidaEnemigos")*1.15f);
                PlayerPrefs.SetInt("Ronda", PlayerPrefs.GetInt("Ronda")+1);
            }
            tiempoEntreEnemigosActual = TEE;
            int posicion = Random.Range(0, 4);
            GameObject enemy = Instantiate(Enemigo, posiciones[posicion], Quaternion.identity);
            enemy.GetComponent<LivingEntity>().EnemyExp.AddListener(Exp);
            enemy.GetComponent<LivingEntity>().EnemyGold.AddListener(Gold);
            enemies++;
        }
    }

    public void Gold(Vector3 enemyPosition){
        int orogenerado = Random.Range(0, 5);
        for (int i = 0; i < orogenerado; i++)
        {
            Vector3 dispersion = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

            Instantiate(orito, enemyPosition + dispersion, Quaternion.identity);
        }
    }

    public void Exp(){
        PlayerPrefs.SetInt("Exp", PlayerPrefs.GetInt("Exp")+1*PlayerPrefs.GetInt("ExpM"));
    }
}
