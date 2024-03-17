using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject Enemigo;
    public Vector3[] posiciones;
    float tiempoEntreEnemigosActual;
    float TEE;
    public GameObject orito;

    // Start is called before the first frame update
    void Start()
    {
        tiempoEntreEnemigosActual = 2;
        TEE = 20;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoEntreEnemigosActual -= Time.deltaTime;
        if (tiempoEntreEnemigosActual <= 0)
        {
            tiempoEntreEnemigosActual = TEE;
            int posicion = Random.Range(0, 4);
            GameObject enemy = Instantiate(Enemigo, posiciones[posicion], Quaternion.identity);
            enemy.GetComponent<LivingEntity>().EnemyExp.AddListener(Exp);
            enemy.GetComponent<LivingEntity>().EnemyGold.AddListener(Gold);
        }
    }

    public void Exp(){
        Debug.Log("Exp");
    }

    public void Gold(Vector3 enemyPosition){
        int orogenerado = Random.Range(0, 5);
        for (int i = 0; i < orogenerado; i++)
        {
            Vector3 dispersion = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

            Instantiate(orito, enemyPosition + dispersion, Quaternion.identity);
        }
    }
}
