using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bala : MonoBehaviour
{
    public float velocidad = 10.0f;
    public LayerMask capaDestruir;
    float damage;
    public GameObject Explosion;
    public GameObject RealExplosion;

    void Start()
    {
        Destroy(gameObject, 2.0f);
        switch(PlayerPrefs.GetString("ArmaActual")){
                case "HANDGUN":
                    damage = 1;
                    break;
                case "UZI":
                    damage = 1f;
                    break;
                case "M4":
                    damage = 2f;
                    break;
                case "AK":
                    damage = 5f;
                    break;
                case "SHOTGUN":
                    damage = 8f;
                    break;
                case "GATLING":
                    damage = 5f;
                    break;
                case "RPG":
                    damage = 100f;
                    break;
            }
        damage *= PlayerPrefs.GetFloat("DamageM");
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
                        GameObject explotioReal = Instantiate(RealExplosion, hit.collider.transform.position, hit.collider.transform.rotation);
                        Destroy(explotioReal, 0.3f);
                    }
                }
            }
            Destroy(gameObject);
        }
    }

    

}
