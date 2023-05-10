using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10.0f;
    public float xRange = 20.0f;
    public float zRange = 13.0f;
    public int health = 100;

    public GameObject projectPrepab;

    SliderHealthBarController healthBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime,0, verticalInput * speed * Time.deltaTime);

        if ( transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if( transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectPrepab, transform.position, projectPrepab.transform.rotation);
        }
        
    }
    public void updateHealth(int change)
    {
        healthBar = gameObject.GetComponent<SliderHealthBarController>();
        if (health >= 10 && health <= 100)
        {
            healthBar.addDamage(-change);
            health += change;
            Debug.Log(health);
        }
        if (health < 10)
        {
            Debug.Log("GAME OVER");
            GameManager.instance.scoreText.gameObject.SetActive(false);
            GameManager.instance.panel.SetActive(true);
            GameManager.instance.SetTextHighScore();
        }
        
    }
}
