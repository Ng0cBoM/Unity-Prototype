using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedController : MonoBehaviour
{
    PlayerController player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<PlayerController>();
            if (player.health < 100)
            {
                player.updateHealth(10);
            }            
            Destroy(gameObject);
            GameManager.instance.SetCurScore();
            GameManager.instance.isExistsFood = false;
        }
    }

}
