using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotio : MonoBehaviour
{
    // Start is called before the first frame update
    float damage;
    void Start(){

        
    }
    
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log(other.gameObject.name);
        damage = (100 * PlayerPrefs.GetFloat("DamageM"))/2;
        if(other.tag == "Player")
        {
            damage *= 0.10f * PlayerPrefs.GetFloat("Armor");
        }
        IDamageable damageableObject = other.GetComponent<IDamageable>();
        
        damageableObject.TakeDamage(damage);
       
    }
}
