using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject Enemigo;
    Vector3[] posiciones;
    float tiempoEntreEnemigosActual;
    float TEE;

    // Start is called before the first frame update
    void Start()
    {
        tiempoEntreEnemigosActual = 5;
        TEE = 5;
        posiciones[0] = new Vector3(223.04f, 12.75f, 157.3f);
        posiciones[1] = new Vector3(273.23f, 14.87f, 192.09f);
        posiciones[2] = new Vector3(131.67f, 13.45f, 237.59f);
        posiciones[3] = new Vector3(264.02f, 14.18f, 305.02f);
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
