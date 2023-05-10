using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    SliderHealthBarController healthBar;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        healthBar = gameObject.GetComponent<SliderHealthBarController>();
        if (other.gameObject.tag == "Banana")
        {
            healthBar.addDamage(10);
            Destroy(other.gameObject);            
        }     
        else if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.updateHealth(-damage);
        }
    }
}
