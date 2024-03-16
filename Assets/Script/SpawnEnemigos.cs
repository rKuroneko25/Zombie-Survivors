using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject Enemigo;
    public Vector3[] posiciones;
    float tiempoEntreEnemigosActual;
    float TEE;

    // Start is called before the first frame update
    void Start()
    {
        tiempoEntreEnemigosActual = 5;
        TEE = 5;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoEntreEnemigosActual -= Time.deltaTime;
        if (tiempoEntreEnemigosActual <= 0)
        {
            tiempoEntreEnemigosActual = TEE;
            int posicion = Random.Range(0, 4);
            Instantiate(Enemigo, posiciones[posicion], Quaternion.identity);
        }
    }
}
