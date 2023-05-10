using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBarController : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth;
    private int currentHealth;

    public Slider healthSlider;
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void addDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0) makeDead();
    }

    void makeDead()
    {
        if (gameObject.tag != "Player")
        {
            GameManager.instance.UpdateScore(maxHealth/10);
        }        
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
