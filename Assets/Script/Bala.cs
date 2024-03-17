using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bala : MonoBehaviour
{
    public float velocidad = 10.0f;
    public LayerMask capaDestruir;
    public float damage;
    public GameObject Explosion;

    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistancia = Time.deltaTime * velocidad;
        transform.Translate(Vector3.forward * moveDistancia);
        CheckColision(moveDistancia);
    }

    void CheckColision(float moveDistancia)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, moveDistancia, capaDestruir))
        {
            if(hit.collider.tag == "Enemigo"){
                IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
                if(damageableObject != null)
                {
                    damageableObject.TakeDamage(damage);
                    if(PlayerPrefs.GetString("ArmaActual") == "RPG"){
                        FindObjectOfType<AudioManager>().Play("Explosion");
                        GameObject explotio = Instantiate(Explosion, transform.position, transform.rotation);
                        Destroy(explotio, 0.6f);
                    }
                }
            }
            Destroy(gameObject);
        }
    }

    

}
