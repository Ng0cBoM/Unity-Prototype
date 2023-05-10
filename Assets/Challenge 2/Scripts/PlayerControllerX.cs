using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float timeSpawnDog;
    private float lastTime = 0;


    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if(Time.time - lastTime > timeSpawnDog){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                lastTime = Time.time;
            }
        }
        Debug.Log(Time.time);        
    }
}
